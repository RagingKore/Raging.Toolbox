using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Raging.Toolbox.Extensions
{
    public static class SerializationExtensions
    {
        private static readonly ConcurrentDictionary<Type, XmlSerializer> XmlSerializers =
            new ConcurrentDictionary<Type, XmlSerializer>();

        private static readonly ConcurrentDictionary<Type, XmlSerializer> XmlSerializersWithOverrides =
            new ConcurrentDictionary<Type, XmlSerializer>();

        private static readonly ConcurrentDictionary<Type, DataContractJsonSerializer> DataContractJsonSerializers =
            new ConcurrentDictionary<Type, DataContractJsonSerializer>();

        private static readonly ConcurrentDictionary<Type, DataContractSerializer> DataContractSerializers =
            new ConcurrentDictionary<Type, DataContractSerializer>();

        public static string ToXml(this object obj, XmlAttributeOverrides overrides = null)
        {
            var xmlSerializer = overrides == null
                ? XmlSerializers.GetOrAdd(obj.GetType(), type => new XmlSerializer(type))
                : XmlSerializersWithOverrides.GetOrAdd(obj.GetType(), type => new XmlSerializer(type, overrides));

            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, obj);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T FromXml<T>(this string xml, XmlAttributeOverrides overrides = null)
        {
            var xmlSerializer = overrides == null
                ? XmlSerializers.GetOrAdd(typeof(T), type => new XmlSerializer(type))
                : XmlSerializersWithOverrides.GetOrAdd(typeof(T), type => new XmlSerializer(type, overrides));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                return (T)xmlSerializer.Deserialize(stream);
            }
        }

        public static object FromXml(this string xml, Type type, XmlAttributeOverrides overrides = null)
        {
            var xmlSerializer = overrides == null
                ? XmlSerializers.GetOrAdd(type, t => new XmlSerializer(t))
                : XmlSerializersWithOverrides.GetOrAdd(type, t => new XmlSerializer(t, overrides));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                return xmlSerializer.Deserialize(stream);
            }
        }

        public static byte[] ToBinary(this object obj)
        {
            var serializer = DataContractSerializers
              .GetOrAdd(obj.GetType(), type => new DataContractSerializer(type));

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return stream.ToArray();
            }
        }

        public static T FromBinary<T>(this byte[] bytes)
        {
            var serializer = DataContractJsonSerializers
                .GetOrAdd(typeof(T), type => new DataContractJsonSerializer(type));

            using (var stream = new MemoryStream(bytes))
            {
                return (T)serializer.ReadObject(stream);
            }
        }

        public static string ToJson(this object obj)
        {
            var serializer = DataContractJsonSerializers
                .GetOrAdd(obj.GetType(), type => new DataContractJsonSerializer(type));

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T FromJson<T>(this string json)
        {
            var serializer = DataContractJsonSerializers
                .GetOrAdd(typeof(T), type => new DataContractJsonSerializer(type));

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}

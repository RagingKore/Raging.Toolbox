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

        private static readonly ConcurrentDictionary<Type, DataContractJsonSerializer> DataContractJsonSerializers =
            new ConcurrentDictionary<Type, DataContractJsonSerializer>();

        public static string ToXml(this object obj)
        {
            var xmlSerializer = XmlSerializers
                .GetOrAdd(obj.GetType(), type => new XmlSerializer(type));

            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, obj);

                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        public static T FromXml<T>(this string xml)
        {
            var xmlSerializer = XmlSerializers
                .GetOrAdd(typeof(T), t => new XmlSerializer(t));

            using (var stream = new MemoryStream(Encoding.Default.GetBytes(xml)))
            {
                return (T)xmlSerializer.Deserialize(stream);
            }
        }

        public static byte[] ToBinary(this object obj)
        {
            using (var stream = new MemoryStream())
            {
                new NetDataContractSerializer().WriteObject(stream, obj);
                return stream.ToArray();
            }
        }

        public static T FromBinary<T>(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                return (T)new NetDataContractSerializer().ReadObject(stream);
            }
        }

        public static string ToJson(this object obj)
        {
            var serializer = DataContractJsonSerializers
                .GetOrAdd(obj.GetType(), type => new DataContractJsonSerializer(type));

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        public static T FromJson<T>(this string json)
        {
            var serializer = DataContractJsonSerializers
                .GetOrAdd(typeof(T), type => new DataContractJsonSerializer(type));

            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}

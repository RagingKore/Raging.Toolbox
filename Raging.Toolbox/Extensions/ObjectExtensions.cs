using System;
using System.ComponentModel;
using System.Globalization;

namespace Raging.Toolbox.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object source)
        {
            return null == source;
        }

        public static bool IsNotNull(this object source)
        {
            return null != source;
        }

        public static bool IsNumericType(this object source)
        {
            return source.GetType().IsNumericType();
        }

        public static T To<T>(this object source)
        {
            return source.To<T>(CultureInfo.InvariantCulture);
        }

        public static T To<T>(this object source, CultureInfo ci)
        {
            var type = typeof(T);

            if (source.GetType().UnderlyingSystemType == type)
                return (T)source;

            if (type.IsPrimitive)
                return (T)Convert.ChangeType(source, type, ci);

            if (type.IsEnum)
                return (T)Enum.Parse(type, source.ToString());

            if (source.GetType().UnderlyingSystemType == typeof(string))
                return (T)TypeDescriptor
                    .GetConverter(type)
                    .ConvertFromString(null, ci, (string)source);

            return (T)TypeDescriptor
                .GetConverter(type)
                .ConvertFrom(null, ci, source);
        }

        public static bool TryTo<T>(this object source, out T convertedValue)
        {
            return source.TryTo(CultureInfo.InvariantCulture, out convertedValue);
        }

        public static bool TryTo<T>(this object source, CultureInfo ci, out T convertedValue)
        {
            try
            {
                convertedValue = source.To<T>(ci);
                return true;
            }
            catch (Exception)
            {
                convertedValue = default(T);
                return false;
            }
        }
    }
}
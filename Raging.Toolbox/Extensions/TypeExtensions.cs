using System;
using System.Linq;

namespace Raging.Toolbox.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        ///     A Type extension method that validates if the given Type is assignable to the generic type.
        /// </summary>
        /// <param name="givenType">The givenType to act on.</param>
        /// <param name="genericType">Type of the generic.</param>
        /// <returns>
        ///     true if assignable to generic type, false if not.
        /// </returns>
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            if(interfaceTypes.Any(type => type.IsGenericType && type.GetGenericTypeDefinition() == genericType))
                return true;

            if(givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            return givenType.BaseType != null && IsAssignableToGenericType(givenType.BaseType, genericType);
        }

        /// <summary>
        ///     A Type extension method that query if 'source' is a numeric type.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>true if type is a numeric type, false if not.</returns>
        public static bool IsNumericType(this Type source)
        {
            switch(Type.GetTypeCode(source))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>A Type extension method that gets the value of any system attribute.</summary>
        /// <remarks>Sergio Silveira, 24-11-2014.</remarks>
        /// <tparam name="TAttribute">Type of the attribute.</tparam>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="type">The type to act on.</param>
        /// <param name="valueSelector">The value selector.</param>
        /// <returns>The attribute value.</returns>
        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            var attribute = type
                .GetCustomAttributes(typeof(TAttribute), true)
                .FirstOrDefault() as TAttribute;

            return attribute != null
                ? valueSelector(attribute)
                : default(TValue);
        }

        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
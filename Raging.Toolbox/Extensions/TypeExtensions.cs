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
            switch (Type.GetTypeCode(source))
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
    }
}
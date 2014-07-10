using System.Collections.Generic;
using System.ComponentModel;

namespace Raging.Toolbox.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// A T extension method that query if 'source' equals it's default value.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">   The object to act on. </param>
        ///
        /// <returns>
        /// true if default, false if not.
        /// </returns>
        public static bool IsDefault<T>(this T source)
        {
            // To avoid boxing, the best way to compare generics for equality is with EqualityComparer<T>.Default. 
            // This respects IEquatable<T> (without boxing) as well as object.Equals, and handles all the Nullable<T> "lifted" nuances.
            // This will match:
            //     - null for classes
            //     - null (empty) for Nullable<T>
            //     - zero/false/etc for other structs
            // By Marc Gravell.
            // Source: http://stackoverflow.com/a/864860/503085
            // 
            return EqualityComparer<T>.Default.Equals(source, default(T));
        }

        /// <summary>
        /// A T extension method that query if 'source' does not equals it's default value.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">   The object to act on. </param>
        ///
        /// <returns>
        /// true if not default, false if not.
        /// </returns>
        public static bool IsNotDefault<T>(this T source)
        {
            return !IsDefault(source);
        }

        /// <summary>
        /// A T extension method that gets the value for the description attribute for the given object source
        /// </summary>
        ///
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="source">The source to act on.</param>
        ///
        /// <returns>
        /// A string.
        /// </returns>
        public static string Description<T>(this T source)
        {
            var type = source.GetType();

            DescriptionAttribute[] descriptions;

            if (type.IsEnum)
            {
                descriptions = (DescriptionAttribute[])type
                    .GetField(source.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            else
            {
                descriptions = (DescriptionAttribute[])type
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
            }

            return descriptions.Length == 0 ? null : descriptions[0].Description;
        }
    }
}
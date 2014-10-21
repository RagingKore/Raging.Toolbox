using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Raging.Toolbox.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     An Enum extension method that returns the description from an Enum value.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     A string.
        /// </returns>
        public static string Description(this Enum source)
        {
            var type = source.GetType();

            var attribute = type
                .GetField(source.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute != null
                ? attribute.Description
                : null;
        }

        /// <summary>
        ///     An Enum extension method that returns the description from an Enum value and converts it to the provided Type.
        /// </summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="source">The source to act on.</param>
        /// <returns>A T.</returns>
        public static T DescriptionAs<T>(this Enum source)
        {
            return source.Description().To<T>();
        }

        /// <summary>
        ///     An Enum extension method that returns the description from an Enum value and converts it to the provided Type.
        /// </summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="source">The source to act on.</param>
        /// <param name="ci">The ci.</param>
        /// <returns>A T.</returns>
        public static T DescriptionAs<T>(this Enum source, CultureInfo ci)
        {
            return source.Description().To<T>(ci);
        }
    }
}
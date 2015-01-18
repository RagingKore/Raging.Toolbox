using System;
using System.ComponentModel;
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
    }
}
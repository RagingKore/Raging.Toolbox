using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Raging.Toolbox.Extensions
{
    public static class EnumExtensions
    {
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

        public static T DescriptionAs<T>(this Enum source)
        {
            return source.Description().To<T>();
        }

        public static T DescriptionAs<T>(this Enum source, CultureInfo ci)
        {
            return source.Description().To<T>(ci);
        }
    }
}
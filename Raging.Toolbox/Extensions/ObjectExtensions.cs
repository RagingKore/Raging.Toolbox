using System;
using System.ComponentModel;
using System.Globalization;

namespace Raging.Toolbox.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// An Object extension method that gets the value for the description attribute of any given object source, and converts it to the generic type.
        /// </summary>
        ///
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="source">It is the object used to deep clone.</param>
        ///
        /// <returns>
        /// A T.
        /// </returns>
        public static T DescriptionAs<T>(this Object source)
        {
            return source.Description().To<T>();
        }

        public static T DescriptionAs<T>(this Object source, CultureInfo ci)
        {
            return source.Description().To<T>(ci);
        }
    }
}
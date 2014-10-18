using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace Raging.Toolbox.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        ///     A T extension method that query if 'source' equals it's default value.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="source">The object to act on.</param>
        /// <returns>true if default, false if not.</returns>
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
        ///     A T extension method that query if 'source' does not equals it's default value.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="source">The object to act on.</param>
        /// <returns>true if not default, false if not.</returns>
        public static bool IsNotDefault<T>(this T source)
        {
            return !IsDefault(source);
        }

        public static bool EnsureThat<T>(this T source, params Expression<Func<T, bool>>[] actions)
        {
            return actions.All(expression => source.EnsureThat(expression));
        }

        public static bool EnsureThat<T>(this T source, Expression<Func<T, bool>> action)
        {
            return action.Compile()(source);
        }

        public static T DeepCopy<T>(this T objectToCopy)
        {
            return objectToCopy
                .ToBinary()
                .FromBinary<T>();
        }
    }
}
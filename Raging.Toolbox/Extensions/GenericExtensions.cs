using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        /// <remarks>
        ///     To avoid boxing, the best way to compare generics for equality is with EqualityComparer&lt;T&gt;.Default.<br/>
        ///     This respects IEquatable&lt;T&gt; (without boxing) as well as object.Equals, and handles all the Nullable&lt;T&gt; "lifted" nuances.<br/>
        ///     This will match:<br/>
        ///         - null for classes<br/>
        ///         - null (empty) for Nullable&lt;T&gt;<br/>
        ///         - zero/false/etc for other structs<br/>
        ///     By Marc Gravell.<br/>
        ///     Source: http://stackoverflow.com/a/864860/503085
        /// </remarks>
        public static bool IsDefault<T>(this T source)
        { 
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

        /// <summary>A T extension method that ensures that all conditions are valid for a given generic object.</summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="source">The object to act on.</param>
        /// <param name="conditions">A variable-length parameters list containing conditions.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool EnsureThat<T>(this T source, params Expression<Func<T, bool>>[] conditions)
        {
            return conditions.All(condition => condition.Compile()(source));
        }

        /// <summary>
        ///     A T extension method that creates a deep copy of a given generic object,
        ///     using a json serializer.
        /// </summary>
        /// <tparam name="T">Generic type parameter.</tparam>
        /// <param name="source">The object to act on.</param>
        /// <returns>A copy of the given generic object.</returns>
        public static T DeepCopy<T>(this T source)
        {
            return source.ToJson().FromJson<T>();
        }
    }
}
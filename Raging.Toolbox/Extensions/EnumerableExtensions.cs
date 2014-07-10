using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Raging.Toolbox.Helpers;

namespace Raging.Toolbox.Extensions
{
    // ReSharper disable PossibleMultipleEnumeration
    // ReSharper disable once AssignNullToNotNullAttribute
    public static class EnumerableExtensions
    {
        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that queries if the collection is null or empty.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">   the source enumerable. </param>
        ///
        /// <returns>
        /// true if a null or is t>, false if not.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that return an empty collection if null.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">   the source enumerable. </param>
        ///
        /// <returns>
        /// An empty enumerator that allows foreach to be used to process the collection.
        /// </returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that applies an operation to all items in this
        /// collection.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">   the source enumerable. </param>
        /// <param name="action">   The action. </param>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Check.ForNull(() => source);
            Check.ForNull(() => action);

            foreach(var item in source) action(item);

            return source;
        }

        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that applies an operation to all items in this
        /// collection in parallel.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">   the source enumerable. </param>
        /// <param name="action">   The action. </param>
        /// <param name="options">  Options for controlling the operation. </param>
        public static IEnumerable<T> ParallelForEach<T>(this IEnumerable<T> source, Action<T> action, ParallelOptions options = null)
        {
            if(options.IsNull())
                Parallel.ForEach(source, action);
            else
                Parallel.ForEach(source, options, action);

            return source;
        }

        /// <summary>
        /// An IEnumerable&lt;string&gt; extension method that joins all strings in the collection to 
        /// a single separated string.
        /// </summary>
        ///
        /// <param name="source">       the source enumerable. </param>
        /// <param name="separator">    (Optional) the separator. </param>
        ///
        /// <returns>
        /// A string.
        /// </returns>
        public static string Join(this IEnumerable<string> source, string separator = ",")
        {
            Check.ForNull(() => source);
            Check.ForNullOrEmpty(() => separator);

            return string.Join(separator, source);
        }

        public static IEnumerable<T> Apply<T>(this IEnumerable<T> source, Action<T> action)
        {
            Check.ForNull(() => source);
            Check.ForNull(() => action);

            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }

        public static IEnumerable<TSource> Apply<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            Check.ForNull(() => source);
            Check.ForNull(() => action);

            var i = 0;
            foreach (var item in source)
            {
                action(item, i);
                yield return item;
                i += 1;
            }
        }


        /// <summary>
        /// An IEnumerable&lt;TSource&gt; extension method to order with direction.
        /// </summary>
        ///
        /// <typeparam name="TSource">Type of the source.</typeparam>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <param name="source">the source enumerable.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="descending">true to descending.</param>
        ///
        /// <returns>
        /// An IOrderedEnumerable&lt;TSource&gt;
        /// </returns>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            bool descending)
        {
            Check.ForNull(() => source);

            return descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

        /// <summary>
        /// An IQueryable&lt;TSource&gt; extension method to order with direction.
        /// </summary>
        ///
        /// <typeparam name="TSource">Type of the source.</typeparam>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <param name="source">the source enumerable.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="descending">true to descending.</param>
        ///
        /// <returns>
        /// An IOrderedEnumerable&lt;TSource&gt;
        /// </returns>
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            bool descending)
        {
            Check.ForNull(() => source);

            return descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }
    }
}
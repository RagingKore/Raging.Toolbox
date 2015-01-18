using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return !source.IsNullOrEmpty();
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
            Guard.Null(() => source);
            Guard.Null(() => action);

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
            Guard.Null(() => source);
            Guard.NullOrEmpty(() => separator);

            return string.Join(separator, source);
        }

        public static IEnumerable<T> Apply<T>(this IEnumerable<T> source, Action<T> action)
        {
            Guard.Null(() => source);
            Guard.Null(() => action);

            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }

        public static IEnumerable<TSource> Apply<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            Guard.Null(() => source);
            Guard.Null(() => action);

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
            Guard.Null(() => source);

            return descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

        /// <summary>
        ///     An IQueryable&lt;TSource&gt; extension method to order with direction.
        /// </summary>
        /// <typeparam name="TSource">Type of the source.</typeparam>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <param name="source">the source enumerable.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="descending">true to descending.</param>
        /// <returns>
        ///     An IOrderedEnumerable&lt;TSource&gt;
        /// </returns>
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            bool descending)
        {
            Guard.Null(() => source);

            return descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

        /// <summary>
        /// An extension method that joins all members of the collection to 
        ///     a single separated string.
        /// </summary>
        /// <typeparam name="T">A type that overrides the object.ToString() method.</typeparam>
        /// <param name="source">The value to act on.</param>
        /// <param name="separator">(Optional) the separator. By default, a comma is used.</param>
        /// <returns>A string.</returns>
        public static string Join<T>(this IEnumerable<T> source, string separator = ",")
        {
            return string.Join(separator, source);
        }

        /// <summary>
        ///     Returns all distinct elements of the given source, where "distinctness"
        ///     is determined via a projection and the default equality comparer for the projected type.
        /// </summary>
        /// <remarks>
        ///     This operator uses deferred execution and streams the results, although
        ///     a set of already-seen keys is retained. If a key is seen multiple times,
        ///     only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <returns>
        ///     A sequence consisting of distinct elements from the source sequence,
        ///     comparing them by the specified key projection.
        /// </returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }

        /// <summary>
        ///     Returns all distinct elements of the given source, where "distinctness"
        ///     is determined via a projection and the specified comparer for the projected type.
        /// </summary>
        /// <remarks>
        ///     This operator uses deferred execution and streams the results, although
        ///     a set of already-seen keys is retained. If a key is seen multiple times,
        ///     only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <param name="comparer">
        ///     The equality comparer to use to determine whether or not keys are equal.
        ///     If null, the default equality comparer for <c>TSource</c> is used.
        /// </param>
        /// <returns>
        ///     A sequence consisting of distinct elements from the source sequence,
        ///     comparing them by the specified key projection.
        /// </returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            Guard.Null(() => source, source);
            Guard.Null(() => keySelector, keySelector);

            return DistinctByImpl(source, keySelector, comparer);
        }

        private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(
            IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            var knownKeys = new HashSet<TKey>(comparer);
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }
    }
}
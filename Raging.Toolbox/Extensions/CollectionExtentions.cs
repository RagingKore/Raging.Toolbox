using System.Collections.Generic;

namespace Raging.Toolbox.Extensions
{
    public static class CollectionExtentions
    {
        /// <summary>
        ///     An ICollection&lt;T&gt; extension method that adds a range of items to the collection.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="source">The collection.</param>
        /// <param name="items">The items.</param>
        /// <returns>An ICollection&lt;T&gt;.</returns>
        public static ICollection<T> AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            Guard.Null(() => source);

            items.ForEach(source.Add);

            return source;
        }

        /// <summary>
        ///     An ICollection&lt;T&gt; extension method that removes the range.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="source">The collection.</param>
        /// <param name="items">The items.</param>
        /// <returns>An ICollection&lt;T&gt;</returns>
        public static ICollection<T> RemoveRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            Guard.Null(() => source);
            
            items.ForEach(item => source.Remove(item));

            return source;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Raging.Toolbox
{
    /// <summary>
    ///     A static class that exposes methods for creating generic comparers.
    /// </summary>
    /// <tparam name="T">Generic type parameter.</tparam>
    public static class EqualityHelper<T>
    {
        /// <summary>
        ///     Creates a comparer.
        /// </summary>
        /// <tparam name="V">Generic type parameter.</tparam>
        /// <param name="keySelector">The key selector.</param>
        /// <returns>The new comparer.</returns>
        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector)
        {
            return CreateComparer(keySelector, null);
        }

        /// <summary>
        ///     Creates a comparer.
        /// </summary>
        /// <tparam name="V">Generic type parameter.</tparam>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>The new comparer.</returns>
        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            return new KeyEqualityComparer<V>(keySelector, comparer);
        }

        private class KeyEqualityComparer<V> : IEqualityComparer<T>
        {
            private readonly IEqualityComparer<V> comparer;
            private readonly Func<T, V> keySelector;

            public KeyEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                if(keySelector == null)
                    throw new ArgumentNullException("keySelector");

                this.keySelector = keySelector;
                this.comparer = comparer ?? EqualityComparer<V>.Default;
            }

            public bool Equals(T x, T y)
            {
                return this.comparer.Equals(this.keySelector(x), this.keySelector(y));
            }

            public int GetHashCode(T obj)
            {
                return this.comparer.GetHashCode(this.keySelector(obj));
            }
        }
    }
}
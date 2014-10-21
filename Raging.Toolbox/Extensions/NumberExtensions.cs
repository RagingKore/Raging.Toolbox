using System.Collections.Generic;

namespace Raging.Toolbox.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        ///     Generates a sequence of int64 numbers within a specified range.
        /// </summary>
        /// <param name="start">The value of the first int64 in the sequence.</param>
        /// <param name="count">The number of sequential int64's to generate.</param>
        /// <returns>
        ///     An IEnumerable that contains a range of sequential int64's numbers.
        /// </returns>
        public static IEnumerable<long> Range(this long start, int count)
        {
            for(long current = 0; current < count; ++current)
            {
                yield return start + current;
            }
        }
    }
}
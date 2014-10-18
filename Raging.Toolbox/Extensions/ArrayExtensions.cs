namespace Raging.Toolbox.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        ///     An string[] extension method that joins all strings in the collection to 
        ///     a single separated string.
        /// </summary>
        /// <param name="source">The value to act on.</param>
        /// <param name="separator">(Optional) the separator.</param>
        /// <returns>A string.</returns>
        public static string Join(this string[] source, string separator = ",")
        {
            Guard.ForNullOrEmpty(() => source);
            Guard.ForNullOrEmpty(() => separator);

            return string.Join(separator, source);
        }
    }
}
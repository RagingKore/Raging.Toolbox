using System;
using System.Linq;

namespace Tru.Common.Rebus.Autofac
{
    public static class StringExtensions
    {
        public static bool StartsWithAny(this string source, params string[] compare)
        {
            return compare.Any(comparableValue => source.StartsWith(comparableValue, StringComparison.OrdinalIgnoreCase));
        }

        public static bool StartsWithAny(this string source, StringComparison comparison, params string[] compare)
        {
            return compare.Any(comparableValue => source.StartsWith(comparableValue, comparison));
        }

        public static bool ContainsAny(this string source, params string[] compare)
        {
            return compare.Any(comparableValue => source.Contains(comparableValue, StringComparison.OrdinalIgnoreCase));
        }

        public static bool ContainsAny(this string source, StringComparison comparison, params string[] compare)
        {
            return compare.Any(comparableValue => source.Contains(comparableValue, comparison));
        }

        public static bool Contains(this string source, string compare, StringComparison compareMode = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.IndexOf(compare, compareMode) >= 0;
        }
    }
}
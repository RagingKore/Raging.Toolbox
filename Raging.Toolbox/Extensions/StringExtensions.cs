﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Raging.Toolbox.Extensions
{
    // ReSharper disable InconsistentNaming
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static bool IsNotNullOrWhiteSpace(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNotNullOrEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }

        public static bool Compare(this string source, string compare, CultureInfo ci, CompareOptions options = CompareOptions.OrdinalIgnoreCase)
        {
            return string.Compare(source, compare, ci, options) == 0;
        }

        public static bool Like(this string source, string compare, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return string.Compare(source, compare, comparison) == 0;
        }

        public static bool NotLike(this string source, string compare, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return !Like(source, compare, comparison);
        }

        public static bool LikeAll(this string source, params string[] compare)
        {
            return compare.All(s => source.Like(s));
        }

        public static bool LikeAll(this string source, StringComparison comparison, params string[] compare)
        {
            return compare.All(s => source.Like(s, comparison));
        }

        public static bool NotLikeAll(this string source, params string[] compare)
        {
            return compare.All(s => source.NotLike(s));
        }

        public static bool NotLikeAll(this string source, StringComparison comparison, params string[] compare)
        {
            return compare.All(s => source.NotLike(s, comparison));
        }

        public static bool LikeAny(this string source, params string[] compare)
        {
            return compare.Any(s => source.Like(s));
        }

        public static bool LikeAny(this string source, StringComparison comparison, params string[] compare)
        {
            return compare.Any(s => source.Like(s, comparison));
        }

        public static bool NotLikeAny(this string source, params string[] compare)
        {
            return compare.Any(s => source.NotLike(s));
        }

        public static bool NotLikeAny(this string source, StringComparison comparison, params string[] compare)
        {
            return compare.Any(s => source.NotLike(s, comparison));
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
            if(string.IsNullOrEmpty(source))
                return false;

            return source.IndexOf(compare, compareMode) >= 0;
        }

        public static string FormatWith(this string source, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, source, args);
        }

        public static string FormatWith(this string source, CultureInfo ci, params object[] args)
        {
            return string.Format(ci, source, args);
        }


        /// <summary>
        /// Checks if the string is after another string within a larger string.
        /// </summary>
        /// <param name="source">The current string</param>
        /// <param name="other">The other string</param>
        /// <param name="in">The place to search</param>
        /// <returns>True if this string is before the other</returns>
        public static bool IsAfter(this string source, string other, string @in)
        {
            Guard.Null(() => source);
            Guard.Null(() => other);
            Guard.Null(() => @in);

            var thisIndex = @in.IndexOf(source, StringComparison.Ordinal);
            var otherIndex = @in.IndexOf(other, StringComparison.Ordinal);

            return thisIndex > otherIndex;
        }

        public static byte[] GetBytes(this string source, Encoding encoding)
        {
            return encoding.GetBytes(source);
        }

        public static byte[] GetDefaultBytes(this string source)
        {
            return Encoding.Default.GetBytes(source);
        }

        public static byte[] GetUTF8Bytes(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }

        public static byte[] GetUTF7Bytes(this string source)
        {
            return Encoding.UTF7.GetBytes(source);
        }

        public static byte[] GetUTF32Bytes(this string source)
        {
            return Encoding.UTF32.GetBytes(source);
        }

        public static byte[] GetASCIIBytes(this string source)
        {
            return Encoding.ASCII.GetBytes(source);
        }

        public static byte[] GetUnicodeBytes(this string source)
        {
            return Encoding.Unicode.GetBytes(source);
        }

        public static byte[] GetBigEndianUnicodeBytes(this string source)
        {
            return Encoding.BigEndianUnicode.GetBytes(source);
        }

        /// <summary>
        ///     A string extension method that converts the source to a base 64 string, using 
        ///     utf8 encoding by default.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     source as a string.
        /// </returns>
        public static string ToBase64(this string source)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
        }

        /// <summary>
        /// A string extension method that converts the source to a base 64 string, using 
        /// the provided encoding.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>
        ///     The given data converted to a string.
        /// </returns>
        public static string ToBase64(this string source, Encoding encoding)
        {
            return Convert.ToBase64String(encoding.GetBytes(source));
        }

        /// <summary>
        ///     A string extension method that converts a source from base 64, using 
        ///     utf8 encoding by default.
        /// </summary>
        /// <param name="source">The source to act on.</param>
        /// <returns>
        ///     A string.
        /// </returns>
        public static string FromBase64(this string source)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(source));
        }

        /// <summary>
        ///     A string extension method that converts a source from base 64, using
        ///     the provided encoding.
        /// </summary>
        /// <param name="source">   The source to act on. </param>
        /// <param name="encoding"> The encoding. </param>
        /// <returns>
        ///     A string.
        /// </returns>
        public static string FromBase64(this string source, Encoding encoding)
        {
            return encoding.GetString(Convert.FromBase64String(source));
        }
    }
}
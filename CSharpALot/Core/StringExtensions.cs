using System;
using System.Linq;

namespace CSharpALot.Core
{

    public static class StringExtensions
    {
        /// <summary>
        /// <para>
        /// Extension method. Null-safe.
        /// </para>
        /// <para>
        /// Instance-y wrapper of <see cref="string.IsNullOrEmpty"/>
        /// </para>
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }


        /// <summary>
        /// <para>
        /// Extension method. Null-safe
        /// </para>
        /// </summary>
        public static bool IsNullOrEmptyOrWhitespace(this string str)
        {
            return str.IsNullOrEmpty() || str.Trim() == "";
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// <para>
        /// Similar to string.Contains() but allows you to specify a <see cref="StringComparison"/>.
        /// </para>
        /// </summary>
        public static bool Contains(this string str, string substring, StringComparison comparisonType)
        {
            return str.IndexOf(substring, comparisonType) != -1;
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static bool ContainsAnyOf(this string str, params string[] substrings)
        {
            if (substrings == null)
                return false;

            return substrings.Any(str.Contains);
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static bool ContainsAnyOf(this string str, StringComparison stringComparisonType, params string[] substrings)
        {
            if (substrings == null)
                return false;

            return substrings.Any(sub => str.Contains(sub, stringComparisonType));
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        /// <returns>
        /// True, if this string is equal to any of the specified strings, based on an ordinal comparison
        /// </returns>
        public static bool EqualsAnyOf(this string str, params string[] otherStrings)
        {
            return str.EqualsAnyOf(StringComparison.Ordinal, otherStrings);
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        /// <returns>
        /// True, if this string is equal to any of the specified strings.
        /// </returns>
        public static bool EqualsAnyOf(this string str, StringComparison stringComparison, params string[] otherStrings)
        {
            if (str == null)
                throw new ArgumentNullException("str");

            return otherStrings != null && otherStrings.Any(s => s.Equals(str, stringComparison));
        }
    }

}

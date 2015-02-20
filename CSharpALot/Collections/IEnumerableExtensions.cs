using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpALot.Collections
{

    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <remarks>
    /// Implementation notes:
    ///     - Default 'this' parameter name is 'source', in order to be consistent with .NET
    /// </remarks>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source.SelectMany(l => l);
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> source)
        {
            while (true)
            {
                foreach (var item in source)
                    yield return item;
            }
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static IEnumerable<T> ReverseIf<T>(this IEnumerable<T> source, Func<bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return predicate() ? source.Reverse() : source;
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source
                .GroupBy(keySelector)
                .Select(grouping => grouping.First());
        }


        /// <summary>
        /// <para>
        /// Extension method
        /// </para>
        /// </summary>
        public static IEnumerable<TSource> Except<TSource, TKey>(this IEnumerable<TSource> source, IEnumerable<TSource> other, 
            Func<TSource, TKey> keySelector)
        {
            var otherKeys = other.Select(keySelector);

            // TODO: Inefficient
            return source
                .Where(s =>
                {
                    var sourceKey = keySelector(s);
                    
                    return otherKeys.All(otherKey => !otherKey.Equals(sourceKey));
                });
        }
    }

}

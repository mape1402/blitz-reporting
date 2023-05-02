using System.Collections.Generic;
using System.Linq;

namespace Blitz.Reporting.Analyzers.Extensions
{
    /// <summary>
    /// Contains a series of methods for string types.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Obtains the nearest limit into string from specified delimiters.
        /// </summary>
        /// <param name="chars">String to evaluate.</param>
        /// <param name="startPosition">Initial position.</param>
        /// <param name="delimiters">List of delimiters.</param>
        /// <returns>Returns <see cref="int?"/>.</returns>
        internal static int GetNearLimitFromDelimiters(this string chars, int startPosition, params char[] delimiters)
            => GetIndexesFromDelimiters(chars, startPosition, delimiters).Where(x => x >= default(int)).OrderBy(x => x).FirstOrDefault()
            ?? chars.Length;

        /// <summary>
        /// Obtains a list of indexes into string from specified delimiters.
        /// </summary>
        /// <param name="chars">String to evaluate.</param>
        /// <param name="startPosition">Initial position.</param>
        /// <param name="delimiters">List of delimiters.</param>
        /// <returns>Returns <see cref="IEnumerable{int?}"/></returns>
        internal static IEnumerable<int?> GetIndexesFromDelimiters(this string chars, int startPosition, params char[] delimiters)
        {
            foreach (var delimiter in delimiters)
                yield return chars.IndexOf(delimiter, startPosition);
        }
    }
}

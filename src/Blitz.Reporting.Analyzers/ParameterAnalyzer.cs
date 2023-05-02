using System.Collections.Generic;
using System.Linq;

using Blitz.Reporting.Analyzers.Abstractions;
using Blitz.Reporting.Analyzers.Extensions;
using Blitz.Reporting.Analyzers.Internals;
using Blitz.Reporting.Analyzers.Metadata;

namespace Blitz.Reporting.Analyzers
{
    /// <summary>
    /// Contains methods to obtain parameters from sql query. 
    /// </summary>
    public sealed class ParameterAnalyzer : IParameterAnalyzer
    {
        private const char aroba = InternalCharsForEvaluating.Aroba;
        private const char comma = InternalCharsForEvaluating.Comma;
        private const char space = InternalCharsForEvaluating.Space;

        /// <summary>
        /// Gets all columns from sql query.
        /// </summary>
        /// <param name="sql">Sql query.</param>
        /// <returns>Returns <see cref="IEnumerable{IParameterMetadata}"/>.</returns>
        public IEnumerable<IParameterMetadata> ExtractParametersMetadata(string sql)
            => GetSqlParameterStrings(sql).Distinct().Select(x => new InternalParameterMetadata(x));

        private IEnumerable<string> GetSqlParameterStrings(string sql)
        {
            var index = sql.IndexOf(aroba, default(int));

            while (index >= default(int))
            {
                var limit = sql.GetNearLimitFromDelimiters(index + 1, comma, space, aroba);
                yield return sql.Substring(index, limit - index);

                index = sql.IndexOf(aroba, limit);
            }
        }
    }
}

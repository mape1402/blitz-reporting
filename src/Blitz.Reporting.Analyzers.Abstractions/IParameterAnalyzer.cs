using System.Collections.Generic;

using Blitz.Reporting.Analyzers.Metadata;

namespace Blitz.Reporting.Analyzers.Abstractions
{
    /// <summary>
    /// Contains methods to obtain parameters from sql query. 
    /// </summary>
    public interface IParameterAnalyzer
    {
        /// <summary>
        /// Gets all columns from sql query.
        /// </summary>
        /// <param name="sql">Sql query.</param>
        /// <returns>Returns <see cref="IEnumerable{IParameterMetadata}"/>.</returns>
        IEnumerable<IParameterMetadata> ExtractParametersMetadata(string sql);
    }
}

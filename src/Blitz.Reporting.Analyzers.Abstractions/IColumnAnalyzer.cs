using System.Collections.Generic;

using Blitz.Reporting.Analyzers.Metadata;

namespace Blitz.Reporting.Analyzers.Abstractions
{
    /// <summary>
    /// Contains the methods to obtain the columns from sql query.
    /// </summary>
    public interface IColumnAnalyzer
    {
        /// <summary>
        /// Gets all columns from sql query.
        /// </summary>
        /// <param name="sql">Sql query.</param>
        /// <returns>Returns <see cref="IEnumerable{IColumnMetadata}"/>.</returns>
        IEnumerable<IColumnMetadata> GetColumnsMetadata(string sql);
    }
}

using System.Collections.Generic;

namespace Blitz.Reporting.Analyzers.Metadata
{
    /// <summary>
    /// Represents metadata from a sql query.
    /// </summary>
    public interface ISqlMetatada
    {
        /// <summary>
        /// Gets all column metadata collection from a sql query.
        /// </summary>
        IEnumerable<IColumnMetadata> Columns { get; }

        /// <summary>
        /// Gets all parameter metadata collection from a sql query.
        /// </summary>
        IEnumerable<IParameterMetadata> Parameters { get; }
    }
}

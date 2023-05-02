using System.Threading.Tasks;

using Blitz.Reporting.Analyzers.Metadata;

namespace Blitz.Reporting.Analyzers.Abstractions
{
    /// <summary>
    /// Contains methods to obtain all metadata from sql query.
    /// </summary>
    public interface ISqlAnalyzer
    {
        /// <summary>
        /// Gets metadata from a sql query.
        /// </summary>
        /// <param name="sql">Sql query.</param>
        /// <returns>Returns <see cref="Task{ISqlMetatada}"/>.</returns>
        Task<ISqlMetatada> GetSqlMetatada(string sql);
    }
}

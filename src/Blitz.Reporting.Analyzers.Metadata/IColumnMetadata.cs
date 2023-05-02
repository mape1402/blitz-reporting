
namespace Blitz.Reporting.Analyzers.Metadata
{
    /// <summary>
    /// Represents data of a column into a sql query.
    /// </summary>
    public interface IColumnMetadata
    {
        /// <summary>
        /// Gets name of column.
        /// </summary>
        string Name { get; }
    }
}

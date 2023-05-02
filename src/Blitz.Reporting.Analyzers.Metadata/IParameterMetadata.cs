
namespace Blitz.Reporting.Analyzers.Metadata
{
    /// <summary>
    /// Represents data of a parameter into sql query.
    /// </summary>
    public interface IParameterMetadata
    {
        /// <summary>
        /// Gets name of parameter.
        /// </summary>
        string Name { get; }
    }
}

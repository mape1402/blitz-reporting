using System;

using Blitz.Reporting.Analyzers.Metadata;

namespace Blitz.Reporting.Analyzers.Internals
{
    /// <summary>
    /// Represents data of a column into a sql query.
    /// </summary>
    internal sealed class InternalColumnMetadata : IColumnMetadata
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of <see cref="InternalColumnMetadata"/>.
        /// </summary>
        /// <param name="name"></param>
        internal InternalColumnMetadata(string name)
        {
            name = name.Trim();
            _name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
        }

        /// <summary>
        /// Gets name of column.
        /// </summary>
        public string Name => _name;
    }
}

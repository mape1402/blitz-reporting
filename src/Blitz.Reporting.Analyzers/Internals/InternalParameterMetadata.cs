using System;

using Blitz.Reporting.Analyzers.Exceptions;
using Blitz.Reporting.Analyzers.Metadata;

namespace Blitz.Reporting.Analyzers.Internals
{
    /// <summary>
    /// Represents a parameter from sql query.
    /// </summary>
    internal class InternalParameterMetadata : IParameterMetadata
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of <see cref="InternalParameterMetadata"/>.
        /// </summary>
        /// <param name="name"></param>
        internal InternalParameterMetadata(string name)
        {
            _name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            _name = NormalizeName(_name);
        }

        /// <summary>
        /// Gets name of parameter.
        /// </summary>
        public string Name => _name;

        private string NormalizeName(string name)
        {
            var normalizedName = name.Remove(0, 1).Trim();

            if (string.IsNullOrEmpty(normalizedName))
                throw new InvalidParameterException("Parameter name is not valid.");

            return normalizedName;
        }
    }
}

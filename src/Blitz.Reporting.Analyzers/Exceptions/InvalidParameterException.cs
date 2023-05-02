using System;

namespace Blitz.Reporting.Analyzers.Exceptions
{
    /// <summary>
    /// Represents an error when a parameter name is not valid for metadata or sql query.
    /// </summary>
    [Serializable]
    public class InvalidParameterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvalidParameterException"/>.
        /// </summary>
        public InvalidParameterException() { }

        /// <summary>
        /// Initializes a new instance of <see cref="InvalidParameterException"/>.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidParameterException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of <see cref="InvalidParameterException"/>.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="inner">Inner exception.</param>
        public InvalidParameterException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of <see cref="InvalidParameterException"/>.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming Context.</param>
        protected InvalidParameterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

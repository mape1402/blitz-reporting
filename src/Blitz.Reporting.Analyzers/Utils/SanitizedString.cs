using System;

namespace Blitz.Reporting.Analyzers.Utils
{
    /// <summary>
    /// Represents a string sanitized.
    /// </summary>
    public struct SanitizedString
    {
        private const string space = " ";
        private string _normalizedString;

        /// <summary>
        /// Initializes a new instance of <see cref="SanitizedString"/>.
        /// </summary>
        /// <param name="original">Original string.</param>
        /// <param name="dirtyChars">Chars to remove.</param>
        public SanitizedString(string original, params char[] dirtyChars)
        {
            if (string.IsNullOrWhiteSpace(original))
                throw new ArgumentNullException(nameof(original));

            Original = original;

            _normalizedString = original;
            Normalize(dirtyChars);
        }

        /// <summary>
        /// Gets original string.
        /// </summary>
        public string Original { get; }

        /// <summary>
        /// Gets sanitized string.
        /// </summary>
        public string Sanitized => _normalizedString;

        private void Normalize(char[] dirtyChars)
        {
            foreach (var @char in dirtyChars)
                _normalizedString = _normalizedString.Replace(@char.ToString(), string.Empty);

            _normalizedString = _normalizedString.Replace(Environment.NewLine, space);

            if (string.IsNullOrWhiteSpace(_normalizedString))
                throw new InvalidOperationException("Result is not valid string.");
        }

        /// <summary>
        /// Validates if a <see cref="SanitizedString"/> and <see cref="string"/> objects are equivalents.
        /// </summary>
        /// <param name="a">Struct <see cref="SanitizedString"/>.</param>
        /// <param name="b">Object <see cref="string"/>.</param>
        /// <returns>Returns <see cref="bool"/>.</returns>
        public static bool operator ==(SanitizedString a, string b) => a.Sanitized == b;

        /// <summary>
        /// Validates if a <see cref="SanitizedString"/> and <see cref="string"/> objects aren't equivalents.
        /// </summary>
        /// <param name="a">Struct <see cref="SanitizedString"/>.</param>
        /// <param name="b">Object <see cref="string"/>.</param>
        /// <returns>Returns <see cref="bool"/>.</returns>
        public static bool operator !=(SanitizedString a, string b) => a.Sanitized != b;

        /// <summary>
        /// Validates if two <see cref="SanitizedString"/> objects are equivalents.
        /// </summary>
        /// <param name="a">Struct <see cref="SanitizedString"/>.</param>
        /// <param name="b">Struct <see cref="SanitizedString"/>.</param>
        /// <returns>Returns <see cref="bool"/>.</returns>
        public static bool operator ==(SanitizedString a, SanitizedString b) => a.Sanitized == b.Sanitized;

        /// <summary>
        /// Validates if two <see cref="SanitizedString"/> objects aren't equivalents.
        /// </summary>
        /// <param name="a">Struct <see cref="SanitizedString"/>.</param>
        /// <param name="b">Struct <see cref="SanitizedString"/>.</param>
        /// <returns>Returns <see cref="bool"/>.</returns>
        public static bool operator !=(SanitizedString a, SanitizedString b) => a.Sanitized != b.Sanitized;

        /// <summary>
        /// Validates if an object is equal to current object.
        /// </summary>
        /// <param name="obj">Instance to compare.</param>
        /// <returns>Returns <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SanitizedString normalizedString)
                return normalizedString.Sanitized == Sanitized;

            return false;
        }

        /// <summary>
        /// Gets hash code from this object.
        /// </summary>
        /// <returns>Returns <see cref="int"/>.</returns>
        public override int GetHashCode() => Sanitized.GetHashCode();

        /// <summary>
        /// Reports an integer value for index of string specified into this <see cref="SanitizedString"/>.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="startIndex">Initial position into string.</param>
        /// <returns>Returns <see cref="int"/>.</returns>
        public int IndexOf(string value, int startIndex) => _normalizedString.ToLower().IndexOf(value, startIndex);

        /// <summary>
        /// Reports an integer value for index of string specified into this <see cref="SanitizedString"/>.
        /// </summary>
        /// <param name="value">Char value.</param>
        /// <param name="startIndex">Initial position into string.</param>
        /// <returns>Returns <see cref="int"/>.</returns>
        public int IndexOf(char value, int startIndex) => _normalizedString.ToLower().IndexOf(value, startIndex);
    }
}

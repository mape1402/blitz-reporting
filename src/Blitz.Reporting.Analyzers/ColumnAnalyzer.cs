using System;
using System.Collections.Generic;
using System.Linq;

using Blitz.Reporting.Analyzers.Abstractions;
using Blitz.Reporting.Analyzers.Internals;
using Blitz.Reporting.Analyzers.Metadata;
using Blitz.Reporting.Analyzers.Utils;

namespace Blitz.Reporting.Analyzers
{
    public sealed class ColumnAnalyzer : IColumnAnalyzer
    {
        private const string select = nameof(select);
        private const string from = nameof(from);

        private const char space = InternalCharsForEvaluating.Space;
        private const char openingBracket = InternalCharsForEvaluating.OpeningBracket;
        private const char closingBracket = InternalCharsForEvaluating.ClosingBracket;

        public IEnumerable<IColumnMetadata> GetColumnsMetadata(string sql)
        {
            var sanitizedSql = new SanitizedString(sql);

            int index;
            if (!HasSelectClausule(sanitizedSql, out index))
                return Enumerable.Empty<IColumnMetadata>();

            var limit = GetClausuleLimit(sanitizedSql.Sanitized, index);

            return sanitizedSql.Sanitized.Substring(index, limit - index).Split(',').Select(x => new InternalColumnMetadata(x.Trim().Split(" ").Last()));
        }

        private bool HasSelectClausule(SanitizedString sanitizedSql, out int index)
        {
            index = sanitizedSql.IndexOf(select, default(int));

            if (index < default(int))
                return false;

            index += select.Length;
            return true;
        }

        private int GetClausuleLimit(string sql, int startPosition)
        {
            var stack = new Stack<int>();
            var tempChars = new List<char>();

            for (int i = startPosition; i < sql.Length; i++)
            {
                var @char = sql[i];

                var work = ConditionalFlow<int>
                    .DoOnlyIf(() => IsNotSpace(@char), () => tempChars.Add(@char), -1)
                    .TryOnlyIf(() => IsSelectString(tempChars), () => PushSelectToStack(stack, tempChars))
                    .TryOnlyIf(() => IsNotFromString(tempChars), () => tempChars.Clear())
                    .TryOnlyIf(() => stack.Any(), () => PopSelectFromStack(stack, tempChars))
                    .Try(() => SetIndexBeforeClausuleFrom(i));

                if (work.Result >= default(int))
                    return work.Result;
            }

            throw new InvalidOperationException("Clausule 'FROM' not found into sql query.");
        }

        private bool IsNotSpace(char value) => value != space;

        private bool IsSelectString(IList<char> chars) => string.Join(string.Empty, chars).ToLower() == select;

        private bool IsNotFromString(IList<char> chars) => string.Join(string.Empty, chars).ToLower() != from;

        private void PushSelectToStack(Stack<int> stack, IList<char> chars)
        {
            stack.Push(default);
            chars.Clear();
        }

        private void PopSelectFromStack(Stack<int> stack, IList<char> chars)
        {
            stack.Pop();
            chars.Clear();
        }

        private Func<int, int> SetIndexBeforeClausuleFrom => (index) => index - from.Length;
    }  
}

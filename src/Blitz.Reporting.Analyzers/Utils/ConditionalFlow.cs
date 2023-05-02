using System;

namespace Blitz.Reporting.Analyzers.Utils
{
    public class ConditionalFlow<T>
    {
        private ConditionalFlow(bool shouldContinue, T result, T defaultValue = default(T))
        {
            ShouldContinue = shouldContinue;
            Result = result;
            DefaultValue = defaultValue;
        }

        public T Result { get; private set; }

        private bool ShouldContinue { get; set; }

        private T DefaultValue { get; }

        public static ConditionalFlow<T> DoOnlyIf(Func<bool> onlyIf, Func<T> action, T defaultValue = default(T))
        {
            var @continue = onlyIf();

            return new ConditionalFlow<T>(!@continue, @continue ? action() : default(T), defaultValue);
        }

        public static ConditionalFlow<T> DoOnlyIf(Func<bool> onlyIf, Action action, T defaultValue = default(T))
        {
            var @continue = onlyIf();

            if (@continue)
                action();

            return new ConditionalFlow<T>(!@continue, defaultValue, defaultValue);
        }

        public ConditionalFlow<T> TryOnlyIf(Func<bool> onlyIf, Func<T> action)
        {
            if (!ShouldContinue)
                return this;

            if (onlyIf())
            {
                Result = action();
                ShouldContinue = false;
            }

            return this;
        }

        public ConditionalFlow<T> TryOnlyIf(Func<bool> onlyIf, Action action)
        {
            if (!ShouldContinue)
                return this;

            if (onlyIf())
            {
                action();
                Result = DefaultValue;
                ShouldContinue = false;
            }

            return this;
        }

        public ConditionalFlow<T> Try(Func<T> action)
        {
            if (!ShouldContinue)
                return this;

            Result = action();
            ShouldContinue = false;

            return this;
        }

        public ConditionalFlow<T> Try(Action action)
        {
            if (!ShouldContinue)
                return this;

            action();
            Result = DefaultValue;
            ShouldContinue = false;

            return this;
        }
    }
}

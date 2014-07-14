using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox
{
    public static class Check
    {
        [DebuggerStepThrough]
        public static void ForDefault<T>(T argument)
        {
            // To avoid boxing, the best way to compare generics for equality is with EqualityComparer<T>.Default. 
            // This respects IEquatable<T> (without boxing) as well as object.Equals, and handles all the Nullable<T> "lifted" nuances.
            // This will match:
            //     - null for classes
            //     - null (empty) for Nullable<T>
            //     - zero/false/etc for other structs
            // By Marc Gravell.
            // Source: http://stackoverflow.com/a/864860/503085

            if(!argument.IsDefault()) return;

            var argumentName = typeof(T).GetProperties()[0].Name;

            throw new ArgumentNullException(
                argumentName,
                ErrorMessages.ArgumentCannotBeDefault.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void ForNull(Expression<Func<object>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if (value.IsNotNull()) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentNullException(
                argumentName, 
                ErrorMessages.ArgumentCannotBeNull.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty(Expression<Func<string>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if (value.IsNotNullOrEmpty()) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentNullException(
                argumentName, 
                ErrorMessages.ArgumentCannotBeNullOrEmpty.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value.IsNotNullOrEmpty()) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentNullException(
                argumentName, 
                ErrorMessages.ArgumentCannotBeNullOrEmpty.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void ForNullOrWhiteSpace(Expression<Func<string>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value.IsNotNullOrWhiteSpace()) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentNullException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNullOrWhitespace.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void ForOutOfRange<TArgument>(Expression<Func<TArgument>> argumentExpression, IEnumerable<TArgument> range)
        {
            var value = argumentExpression.Compile()();

            if(range.Contains(value)) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeOutOfRange.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<int>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value >= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegative.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<long>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value >= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegative.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<double>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value >= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegative.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<float>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value >= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegative.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<short>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value >= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegative.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<int>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value > 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<long>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value > 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<double>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value > 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<float>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value > 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<short>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value > 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<int>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value <= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositive.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<long>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value <= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositive.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<double>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value <= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositive.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<float>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value <= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositive.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<short>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value <= 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositive.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<int>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value < 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<long>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value < 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<double>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value < 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<float>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value < 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(argumentName, value));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<short>> argumentExpression)
        {
            var value = argumentExpression.Compile()();

            if(value < 0) return;

            var argumentName = argumentExpression.GetVariableName();

            throw new ArgumentOutOfRangeException(
                argumentName,
                ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(argumentName, value));
        }

        internal static class ErrorMessages
        {
            public static string ArgumentCannotBeDefault          = "'{0}' cannot be default.";
            public static string ArgumentCannotBeNull             = "'{0}' cannot be null.";
            public static string ArgumentCannotBeNullOrEmpty      = "'{0}' cannot be null or empty.";
            public static string ArgumentCannotBeNullOrWhitespace = "'{0}' cannot be null or whitespace.";
            public static string ArgumentCannotBeNegative         = "'{0}' cannot be negative. Was '{1}'.";
            public static string ArgumentCannotBeNegativeOrZero   = "'{0}' cannot be negative or zero. Was '{1}'.";
            public static string ArgumentCannotBePositive         = "'{0}' cannot be positive. Was '{1}'.";
            public static string ArgumentCannotBePositiveOrZero   = "'{0}' cannot be positive or zero. Was '{1}'.";
            public static string ArgumentCannotBeOutOfRange       = "'{0}' cannot be out of range. Was '{1}'.";
        }
    }
}
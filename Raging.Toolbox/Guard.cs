using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox
{
    public static class Guard
    {
        [DebuggerStepThrough]
        public static void ForDefault<T>(T argument)
        {
            //// To avoid boxing, the best way to compare generics for equality is with EqualityComparer<T>.Default. 
            //// This respects IEquatable<T> (without boxing) as well as object.Equals, and handles all the Nullable<T> "lifted" nuances.
            //// This will match:
            ////     - null for classes
            ////     - null (empty) for Nullable<T>
            ////     - zero/false/etc for other structs
            //// By Marc Gravell.
            //// Source: http://stackoverflow.com/a/864860/503085

            if(!argument.IsDefault()) return;

            var argumentName = typeof(T).GetProperties()[0].Name;

            throw new ArgumentNullException(
                argumentName,
                ErrorMessages.ArgumentCannotBeDefault.FormatWith(argumentName));
        }

        [DebuggerStepThrough]
        public static void For<T>(Expression<Func<T>> argumentExpression, Predicate<T> conditions, string errorMessage = null)
        {
            Validate<T, ArgumentException>(
                argumentExpression,
                conditions,
                errorMessage ?? ErrorMessages.ArgumentCannotComplyWithConditions);
        }

        [DebuggerStepThrough]
        public static void ForNull(Expression<Func<object>> argumentExpression)
        {
            Validate<object, ArgumentNullException>(
                argumentExpression,
                value => value.IsNotNull(),
                ErrorMessages.ArgumentCannotBeNull);
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty(Expression<Func<string>> argumentExpression)
        {
            Validate<string, ArgumentNullException>(
                argumentExpression,
                value => value.IsNotNullOrEmpty(),
                ErrorMessages.ArgumentCannotBeNullOrEmpty);
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> argumentExpression)
        {
            Validate<IEnumerable<T>, ArgumentNullException>(
                argumentExpression,
                value => value.IsNotNullOrEmpty(),
                ErrorMessages.ArgumentCannotBeNullOrEmpty);
        }

        [DebuggerStepThrough]
        public static void ForNullOrWhiteSpace(Expression<Func<string>> argumentExpression)
        {
            Validate<string, ArgumentNullException>(
                argumentExpression,
                value => value.IsNotNullOrWhiteSpace(),
                ErrorMessages.ArgumentCannotBeNullOrWhitespace);
        }

        [DebuggerStepThrough]
        public static void ForOutOfRange<TArgument>(Expression<Func<TArgument>> argumentExpression, IEnumerable<TArgument> range)
        {
            Validate<TArgument, ArgumentOutOfRangeException>(
               argumentExpression,
               range.Contains,
               ErrorMessages.ArgumentCannotBeOutOfRange);
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<int>> argumentExpression)
        {
            Validate<int, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value >= 0,
               ErrorMessages.ArgumentCannotBeNegative);
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<long>> argumentExpression)
        {
            Validate<long, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value >= 0,
               ErrorMessages.ArgumentCannotBeNegative);
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<double>> argumentExpression)
        {
            Validate<double, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<float>> argumentExpression)
        {
            Validate<float, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<decimal>> argumentExpression)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<short>> argumentExpression)
        {
            Validate<short, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<int>> argumentExpression)
        {
            Validate<int, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<long>> argumentExpression)
        {
            Validate<long, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value > 0,
               ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<double>> argumentExpression)
        {
            Validate<double, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value > 0,
               ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<float>> argumentExpression)
        {
            Validate<float, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<short>> argumentExpression)
        {
            Validate<short, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<decimal>> argumentExpression)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<int>> argumentExpression)
        {
            Validate<int, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value <= 0,
               ErrorMessages.ArgumentCannotBePositive);
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<long>> argumentExpression)
        {
            Validate<long, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value <= 0,
               ErrorMessages.ArgumentCannotBePositive);
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<double>> argumentExpression)
        {
            Validate<double, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value <= 0,
               ErrorMessages.ArgumentCannotBePositive);
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<float>> argumentExpression)
        {
            Validate<float, ArgumentOutOfRangeException>(
               argumentExpression,
               value => value <= 0,
               ErrorMessages.ArgumentCannotBePositive);
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<short>> argumentExpression)
        {
            Validate<short, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<decimal>> argumentExpression)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<int>> argumentExpression)
        {
            Validate<int, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<long>> argumentExpression)
        {
            Validate<long, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<double>> argumentExpression)
        {
            Validate<double, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<float>> argumentExpression)
        {
            Validate<float, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<short>> argumentExpression)
        {
            Validate<short, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<decimal>> argumentExpression)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                argumentExpression,
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        private static void Validate<TArgument, TException>(
            Expression<Func<TArgument>> argumentExpression,
            Predicate<TArgument> predicate,
            string errorMessageTemplate)
            where TException : Exception
        {
            var value = argumentExpression.Compile()();

            if (predicate(value)) return;

            var argumentName = argumentExpression.GetVariableName();

            var exception = (TException)Activator.CreateInstance(
                typeof(TException),
                argumentName,
                errorMessageTemplate.FormatWith(argumentName));

            throw exception;
        }

        internal static class ErrorMessages
        {
            internal const string ArgumentCannotComplyWithConditions = "'{0}' cannot comply with conditions.";
            internal const string ArgumentCannotBeDefault            = "'{0}' cannot be default.";
            internal const string ArgumentCannotBeNull               = "'{0}' cannot be null.";
            internal const string ArgumentCannotBeNullOrEmpty        = "'{0}' cannot be null or empty.";
            internal const string ArgumentCannotBeNullOrWhitespace   = "'{0}' cannot be null or whitespace.";
            internal const string ArgumentCannotBeNegative           = "'{0}' cannot be negative.";
            internal const string ArgumentCannotBeNegativeOrZero     = "'{0}' cannot be negative or zero.";
            internal const string ArgumentCannotBePositive           = "'{0}' cannot be positive.";
            internal const string ArgumentCannotBePositiveOrZero     = "'{0}' cannot be positive or zero.";
            internal const string ArgumentCannotBeOutOfRange         = "'{0}' cannot be out of range.";
        }
    }
}
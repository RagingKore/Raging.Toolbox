using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox
{
    public static class Guard
    {
        #region . Null .

        public static void Null<T>(Expression<Func<T>> reference) 
        {
            Validate<T, ArgumentNullException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                parameter => parameter.IsDefault(),
                ErrorMessages.ArgumentCannotBeNull);
        }

        /// <summary>
        ///     Ensures the given <paramref name="value"/> is not null.
        ///     It's faster since the reference expression is not compiled to obtain the value.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when parameter is null.
        /// </exception>
        /// <param name="reference">The reference to the parameter.</param>
        /// <param name="value">The value.</param>
        //[DebuggerStepThrough]
        public static void Null<T>(Expression<Func<T>> reference, T value)
        {
            Validate<T, ArgumentNullException>(
               reference.GetParameterName,
               () => value,
               parameter => parameter.IsDefault(),
               ErrorMessages.ArgumentCannotBeNull);
        }

        //[DebuggerStepThrough]
        public static void Null<T>(string name, T value)
        {
            Validate<T, ArgumentNullException>(
               () => name,
               () => value,
               parameter => parameter.IsDefault(),
               ErrorMessages.ArgumentCannotBeNull);
        }

        #endregion

        #region . NullOrEmpty .

        //[DebuggerStepThrough]
        public static void NullOrEmpty(Expression<Func<string>> reference)
        {
            Validate<string, ArgumentNullException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                parameter => parameter.IsNullOrEmpty(),
                ErrorMessages.ArgumentCannotBeNullOrEmpty);
        }

        //[DebuggerStepThrough]
        public static void NullOrEmpty(Expression<Func<string>> reference, string value)
        {
            Validate<string, ArgumentNullException>(
                reference.GetParameterName,
                () => value,
                parameter => parameter.IsNullOrEmpty(),
                ErrorMessages.ArgumentCannotBeNullOrEmpty);
        }

        //[DebuggerStepThrough]
        public static void NullOrEmpty<T>(Expression<Func<IEnumerable<T>>> reference)
        {
            Validate<IEnumerable<T>, ArgumentNullException>(
                 reference.GetParameterName,
                 () => reference.Compile()(),
                 parameter => parameter.IsNullOrEmpty(),
                 ErrorMessages.ArgumentCannotBeNullOrEmpty);
        }

        //[DebuggerStepThrough]
        public static void NullOrEmpty<T>(Expression<Func<IEnumerable<T>>> reference, IEnumerable<T> value)
        {
            Validate<IEnumerable<T>, ArgumentNullException>(
                reference.GetParameterName,
                () => value,
                parameter => parameter.IsNullOrEmpty(),
                ErrorMessages.ArgumentCannotBeNullOrEmpty);
        }

        #endregion

        #region . NullOrWhiteSpace .

        //[DebuggerStepThrough]
        public static void NullOrWhiteSpace(Expression<Func<string>> reference)
        {
            Validate<string, ArgumentNullException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                parameter => parameter.IsNullOrWhiteSpace(),
                ErrorMessages.ArgumentCannotBeNullOrWhitespace);
        }

        //[DebuggerStepThrough]
        public static void NullOrWhiteSpace(Expression<Func<string>> reference, string value)
        {
            Validate<string, ArgumentNullException>(
                reference.GetParameterName,
                () => value,
                parameter => parameter.IsNullOrWhiteSpace(),
                ErrorMessages.ArgumentCannotBeNullOrWhitespace);
        }

        #endregion

        #region . OutOfRange .

        //[DebuggerStepThrough]
        public static void OutOfRange<T>(Expression<Func<T>> reference, IEnumerable<T> range)
        {
            Validate<T, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                parameter => !range.Contains(parameter),
                ErrorMessages.ArgumentCannotBeOutOfRange);
        }

        //[DebuggerStepThrough]
        public static void OutOfRange<T>(Expression<Func<T>> reference, T value, IEnumerable<T> range)
            where T : class
        {
            Validate<T, ArgumentOutOfRangeException>(
               reference.GetParameterName,
               () => value,
               parameter => !range.Contains(parameter),
               ErrorMessages.ArgumentCannotBeOutOfRange);
        }

        #endregion

        #region . Negative & Positive .

        //[DebuggerStepThrough]
        public static void Negative(Expression<Func<int>> reference)
        {
            Validate<int, ArgumentOutOfRangeException>(
               reference.GetParameterName,
               () => reference.Compile()(),
               value => value >= 0,
               ErrorMessages.ArgumentCannotBeNegative);
        }

        //[DebuggerStepThrough]
        public static void Negative(Expression<Func<long>> reference)
        {
            Validate<long, ArgumentOutOfRangeException>(
               reference.GetParameterName,
               () => reference.Compile()(),
               value => value >= 0,
               ErrorMessages.ArgumentCannotBeNegative);
        }

        //[DebuggerStepThrough]
        public static void Negative(Expression<Func<double>> reference)
        {
            Validate<double, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        //[DebuggerStepThrough]
        public static void Negative(Expression<Func<float>> reference)
        {
            Validate<float, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        //[DebuggerStepThrough]
        public static void Negative(Expression<Func<decimal>> reference)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        //[DebuggerStepThrough]
        public static void Negative(Expression<Func<short>> reference)
        {
            Validate<short, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value >= 0,
                ErrorMessages.ArgumentCannotBeNegative);
        }

        //[DebuggerStepThrough]
        public static void NegativeOrZero(Expression<Func<int>> reference)
        {
            Validate<int, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        //[DebuggerStepThrough]
        public static void NegativeOrZero(Expression<Func<long>> reference)
        {
            Validate<long, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        //[DebuggerStepThrough]
        public static void NegativeOrZero(Expression<Func<double>> reference)
        {
            Validate<double, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        //[DebuggerStepThrough]
        public static void NegativeOrZero(Expression<Func<float>> reference)
        {
            Validate<float, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        //[DebuggerStepThrough]
        public static void NegativeOrZero(Expression<Func<short>> reference)
        {
            Validate<short, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        //[DebuggerStepThrough]
        public static void NegativeOrZero(Expression<Func<decimal>> reference)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value > 0,
                ErrorMessages.ArgumentCannotBeNegativeOrZero);
        }

        //[DebuggerStepThrough]
        public static void Positive(Expression<Func<int>> reference)
        {
            Validate<int, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        //[DebuggerStepThrough]
        public static void Positive(Expression<Func<long>> reference)
        {
            Validate<long, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        //[DebuggerStepThrough]
        public static void Positive(Expression<Func<double>> reference)
        {
            Validate<double, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        //[DebuggerStepThrough]
        public static void Positive(Expression<Func<float>> reference)
        {
            Validate<float, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        //[DebuggerStepThrough]
        public static void Positive(Expression<Func<short>> reference)
        {
            Validate<short, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        //[DebuggerStepThrough]
        public static void Positive(Expression<Func<decimal>> reference)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value <= 0,
                ErrorMessages.ArgumentCannotBePositive);
        }

        //[DebuggerStepThrough]
        public static void PositiveOrZero(Expression<Func<int>> reference)
        {
            Validate<int, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        //[DebuggerStepThrough]
        public static void PositiveOrZero(Expression<Func<long>> reference)
        {
            Validate<long, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        //[DebuggerStepThrough]
        public static void PositiveOrZero(Expression<Func<double>> reference)
        {
            Validate<double, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        //[DebuggerStepThrough]
        public static void PositiveOrZero(Expression<Func<float>> reference)
        {
            Validate<float, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        //[DebuggerStepThrough]
        public static void PositiveOrZero(Expression<Func<short>> reference)
        {
            Validate<short, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        //[DebuggerStepThrough]
        public static void PositiveOrZero(Expression<Func<decimal>> reference)
        {
            Validate<decimal, ArgumentOutOfRangeException>(
                reference.GetParameterName,
                () => reference.Compile()(),
                value => value < 0,
                ErrorMessages.ArgumentCannotBePositiveOrZero);
        }

        #endregion

        #region . Default .

        //[DebuggerStepThrough]
        public static void Default<T>(T argument)
        {
            //// To avoid boxing, the best way to compare generics for equality is with EqualityComparer<T>.Default. 
            //// This respects IEquatable<T> (without boxing) as well as object.Equals, and handles all the Nullable<T> "lifted" nuances.
            //// This will match:
            ////     - null for classes
            ////     - null (empty) for Nullable<T>
            ////     - zero/false/etc for other structs
            //// By Marc Gravell.
            //// Source: http://stackoverflow.com/a/864860/503085

            if (!argument.IsDefault()) return;

            var argumentName = typeof(T).GetProperties()[0].Name;

            throw new ArgumentNullException(
                argumentName,
                ErrorMessages.ArgumentCannotBeDefault.FormatWith(argumentName));
        }

        #endregion

        private static void Validate<TParameter, TException>(
            Func<string> nameFunc,
            Func<TParameter> valueFunc,
            Predicate<TParameter> predicate,
            string message)
            where TException : Exception
        {
            if(!predicate(valueFunc())) return;

            var parameterName = nameFunc();

            var exception = (TException)Activator.CreateInstance(
                typeof(TException), 
                parameterName, 
                message.FormatWith(parameterName));

            throw exception;
        }

        internal static class ErrorMessages
        {
            internal const string ArgumentCannotBeDefault            = "Parameter '{0}' cannot be default.";
            internal const string ArgumentCannotBeNull               = "Parameter '{0}' cannot be null.";
            internal const string ArgumentCannotBeNullOrEmpty        = "Parameter '{0}' cannot be null or empty.";
            internal const string ArgumentCannotBeNullOrWhitespace   = "Parameter '{0}' cannot be null or whitespace.";
            internal const string ArgumentCannotBeNegative           = "Parameter '{0}' cannot be negative.";
            internal const string ArgumentCannotBeNegativeOrZero     = "Parameter '{0}' cannot be negative or zero.";
            internal const string ArgumentCannotBePositive           = "Parameter '{0}' cannot be positive.";
            internal const string ArgumentCannotBePositiveOrZero     = "Parameter '{0}' cannot be positive or zero.";
            internal const string ArgumentCannotBeOutOfRange         = "Parameter '{0}' cannot be out of range.";
        }
    }
}
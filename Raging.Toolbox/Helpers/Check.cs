using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.Helpers
{   
    public static class Check
    {
        internal static class ErrorMessages
        {
            public static string ArgumentCannotBeDefault          = "'{0}' cannot be default.";
            public static string ArgumentCannotBeNull             = "'{0}' cannot be null.";
            public static string ArgumentCannotBeNullOrEmpty      = "'{0}' cannot be null or empty.";
            public static string ArgumentCannotBeNullOrWhitespace = "'{0}' cannot be null or whitespace.";
            public static string ArgumentCannotBeNegative         = "'{0}' cannot be negative.";
            public static string ArgumentCannotBeNegativeOrZero   = "'{0}' cannot be negative or zero.";
            public static string ArgumentCannotBePositive         = "'{0}' cannot be positive.";
            public static string ArgumentCannotBePositiveOrZero   = "'{0}' cannot be positive or zero.";
        }

        #region . ForDefault .

        [DebuggerStepThrough]
        public static void ForDefault<T>(T parameter)
        {
            // To avoid boxing, the best way to compare generics for equality is with EqualityComparer<T>.Default. 
            // This respects IEquatable<T> (without boxing) as well as object.Equals, and handles all the Nullable<T> "lifted" nuances.
            // This will match:
            //     - null for classes
            //     - null (empty) for Nullable<T>
            //     - zero/false/etc for other structs
            // By Marc Gravell.
            // Source: http://stackoverflow.com/a/864860/503085
            // 
            if(EqualityComparer<T>.Default.Equals(parameter, default( T )))
            {
                var parameterName = typeof(T).GetProperties()[0].Name;

                throw new ArgumentNullException(
                    parameterName, 
                    ErrorMessages.ArgumentCannotBeDefault.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForDefault<T>(T parameter, string parameterName)
        {
            // To avoid boxing, the best way to compare generics for equality is with EqualityComparer<T>.Default. 
            // This respects IEquatable<T> (without boxing) as well as object.Equals, and handles all the Nullable<T> "lifted" nuances.
            // This will match:
            //     - null for classes
            //     - null (empty) for Nullable<T>
            //     - zero/false/etc for other structs
            // By Marc Gravell.
            // Source: http://stackoverflow.com/a/864860/503085
            // 
            if(EqualityComparer<T>.Default.Equals(parameter, default(T)))
                throw new ArgumentNullException(
                    parameterName,
                    ErrorMessages.ArgumentCannotBeDefault.FormatWith(parameterName));
        }

        #endregion

        #region . ForNull .

        [DebuggerStepThrough]
        public static void ForNull(object parameter, string parameterName)
        {
            if(parameter == null)
                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNull.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNull(Expression<Func<object>> parameterExpression)
        {
            if(parameterExpression.Compile()() == null)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNull.FormatWith(parameterName));
            }
        }

        #endregion

        #region . ForNullOrEmpty .

        [DebuggerStepThrough]
        public static void ForNullOrEmpty(string parameter, string parameterName)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNullOrEmpty.FormatWith(parameterName));      
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty(Expression<Func<string>> parameterExpression)
        {
            if (string.IsNullOrEmpty(parameterExpression.Compile()()))
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNullOrEmpty.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty<T>(IEnumerable<T> parameter, string parameterName)
        {
            if (parameter == null || !parameter.Any())
                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNullOrEmpty.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> parameter)
        {
            var value = parameter.Compile()();

            if (value == null || !value.Any())
            {
                var parameterName = parameter.GetVariableName();

                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNullOrEmpty.FormatWith(parameterName));
            }
        }

        #endregion

        #region . ForNullOrWhiteSpace .

        [DebuggerStepThrough]
        public static void ForNullOrWhiteSpace(string parameter, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNullOrWhitespace.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNullOrWhiteSpace(Expression<Func<string>> parameterExpression)
        {
            if (string.IsNullOrWhiteSpace(parameterExpression.Compile()()))
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentNullException(parameterName, ErrorMessages.ArgumentCannotBeNullOrWhitespace.FormatWith(parameterName));
            }
        }

        #endregion

        #region . ForNegative .

        [DebuggerStepThrough]
        public static void ForNegative(int parameter, string parameterName)
        {
            if (parameter < 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<int>> parameterExpression)
        {
            if (parameterExpression.Compile()() < 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNegative(long parameter, string parameterName)
        {
            if (parameter < 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<long>> parameterExpression)
        {
            if (parameterExpression.Compile()() < 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNegative(double parameter, string parameterName)
        {
            if (parameter < 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<double>> parameterExpression)
        {
            if (parameterExpression.Compile()() < 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNegative(float parameter, string parameterName)
        {
            if (parameter < 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegative(Expression<Func<float>> parameterExpression)
        {
            if (parameterExpression.Compile()() < 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
            }
        }

        #endregion

        #region . ForNegativeOrZero .

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(int parameter, string parameterName)
        {
            if (parameter <= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegative.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<int>> parameterExpression)
        {
            if (parameterExpression.Compile()() <= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(long parameter, string parameterName)
        {
            if (parameter <= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<long>> parameterExpression)
        {
            if (parameterExpression.Compile()() <= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(double parameter, string parameterName)
        {
            if (parameter <= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<double>> parameterExpression)
        {
            if (parameterExpression.Compile()() <= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(float parameter, string parameterName)
        {
            if (parameter <= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForNegativeOrZero(Expression<Func<float>> parameterExpression)
        {
            if (parameterExpression.Compile()() <= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBeNegativeOrZero.FormatWith(parameterName));
            }
        }

        #endregion

        #region . ForPositive .

        [DebuggerStepThrough]
        public static void ForPositive(int parameter, string parameterName)
        {
            if (parameter > 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<int>> parameterExpression)
        {
            if (parameterExpression.Compile()() > 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForPositive(long parameter, string parameterName)
        {
            if (parameter > 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<long>> parameterExpression)
        {
            if (parameterExpression.Compile()() > 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForPositive(double parameter, string parameterName)
        {
            if (parameter > 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<double>> parameterExpression)
        {
            if (parameterExpression.Compile()() > 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForPositive(float parameter, string parameterName)
        {
            if (parameter > 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositive(Expression<Func<float>> parameterExpression)
        {
            if (parameterExpression.Compile()() > 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
            }
        }

        #endregion

        #region . ForPositiveOrZero .

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(int parameter, string parameterName)
        {
            if (parameter >= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositive.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<int>> parameterExpression)
        {
            if (parameterExpression.Compile()() <= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(long parameter, string parameterName)
        {
            if (parameter >= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<long>> parameterExpression)
        {
            if (parameterExpression.Compile()() >= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(double parameter, string parameterName)
        {
            if (parameter >= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<double>> parameterExpression)
        {
            if (parameterExpression.Compile()() >= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(float parameter, string parameterName)
        {
            if (parameter >= 0)
                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
        }

        [DebuggerStepThrough]
        public static void ForPositiveOrZero(Expression<Func<float>> parameterExpression)
        {
            if (parameterExpression.Compile()() >= 0)
            {
                var parameterName = parameterExpression.GetVariableName();

                throw new ArgumentOutOfRangeException(parameterName, ErrorMessages.ArgumentCannotBePositiveOrZero.FormatWith(parameterName));
            }
        }

        #endregion
    }
}

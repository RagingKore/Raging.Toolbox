using System;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Raging.Toolbox.Tests
{
    [TestFixture]
    public class GuardTests : GuardTestsBase
    {
        [Test]
        public void ForNull_ThrowsArgumentNullException_WhenObjectIsNull()
        {
            // arrange   
            object argument = null;

            Action action = () => Guard.ForNull(() => argument);

            // act & assert
            action.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be(ArgumentName);
        }

        [Test]
        public void ForNull_DoesNotThrowArgumentNullException_WhenObjectIsNotNull()
        {
            // arrange
            object argument = 0;

            Action action = () => Guard.ForNull(() => argument);

            // act & assert
            action.ShouldNotThrow<ArgumentNullException>();
        }

        [TestCase(null)]
        [TestCase("")]
        public void ForNullOrEmpty_ThrowsArgumentNullException_WhenStringIsNullOrEmpty(string argument)
        {
            // arrange
            Action action = () => Guard.ForNullOrEmpty(() => argument);

            // act & assert
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be(ArgumentName);
        }

        [Test]
        public void ForNullOrEmpty_DoesNotThrowArgumentNullException_WhenStringIsNotNullOrEmpty()
        {
            // arrange
            string argument = "test";

            Action action = () => Guard.ForNullOrEmpty(() => argument);

            // act & assert
            action.ShouldNotThrow<ArgumentNullException>();
        }

        [TestCase(null)]
        [TestCase("  ")]
        public void ForNullOrWhiteSpace_ThrowsArgumentNullException_WhenStringIsNullOrWhiteSpace(string argument)
        {
            // arrange
            Action action = () => Guard.ForNullOrWhiteSpace(() => argument);

            // act & assert
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be(ArgumentName);
        }

        [Test]
        public void ForNullOrWhiteSpace_DoesNotThrowArgumentNullException_WhenStringIsNotNullOrWhiteSpace()
        {
            // arrange
            string argument = "test";

            Action action = () => Guard.ForNullOrEmpty(() => argument);

            // act & assert
            action.ShouldNotThrow<ArgumentNullException>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "WhenCollectionIsNullOrEmptyTestCases")]
        public void ForNullOrEmpty_ThrowsArgumentNullException_WhenCollectionIsNullOrEmpty(string[] argument)
        {
            // arrange
            Action action = () => Guard.ForNullOrEmpty(() => argument);

            // act & assert
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be(ArgumentName);
        }

        [Test]
        public void ForNullOrEmpty_DoesNotThrowArgumentNullException_WhenCollectionIsNotNullOrEmpty()
        {
            // arrange
            var argument = new[] { "test" };

            Action action = () => Guard.ForNullOrEmpty(() => argument);

            // act & assert
            action.ShouldNotThrow<ArgumentNullException>();
        }

        [Test]
        public void ForOutOfRange_ThrowsArgumentOutOfRangeException_WhenItemDoesNotExistInCollection()
        {
            // arrange
            var range    = new[] { "a", "b" };
            var argument = "c";

            Action action = () => Guard.ForOutOfRange(() => argument, range);

            // act & assert
            action.ShouldThrow<ArgumentOutOfRangeException>().And.ParamName.Should().Be(ArgumentName);
        }

        [Test]
        public void ForOutOfRange_DoesNotThrowArgumentOutOfRangeException_WhenItemExistsInCollection()
        {
            // arrange
            var range    = new[] { "a", "b" };
            var argument = "b";

            Action action = () => Guard.ForOutOfRange(() => argument, range);

            // act & assert
            action.ShouldNotThrow<ArgumentOutOfRangeException>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "NegativeNumbersTestCases")]
        public void ForNegative_ThrowsArgumentOutOfRangeException_WhenNumberIsNegative<TArgument>(TArgument argument)  
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForNegative", () => argument);
             
            // act & assert
            action.ShouldThrow<TargetInvocationException>()
                .And.InnerException.Should()
                .BeOfType<ArgumentOutOfRangeException>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "PositiveNumbersTestCases")]
        [TestCaseSource(typeof(GuardTestsBase), "ZeroNumbersTestCases")]
        public void ForNegative_DoesNotThrowArgumentOutOfRangeException_WhenNumberIsPositiveOrZero<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForNegative", () => argument);

            // act & assert
            action.ShouldNotThrow<Exception>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "NegativeNumbersTestCases")]
        [TestCaseSource(typeof(GuardTestsBase), "ZeroNumbersTestCases")]
        public void ForNegativeOrZero_ThrowsArgumentOutOfRangeException_WhenNumberIsNegativeOrZero<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForNegativeOrZero", () => argument);

            // act & assert
            action.ShouldThrow<TargetInvocationException>()
                .And.InnerException.Should()
                .BeOfType<ArgumentOutOfRangeException>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "PositiveNumbersTestCases")]
        public void ForNegativeOrZero_DoesNotThrowArgumentOutOfRangeException_WhenNumberIsPositive<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForNegativeOrZero", () => argument);

            // act & assert
            action.ShouldNotThrow<Exception>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "PositiveNumbersTestCases")]
        public void ForPositive_ThrowsArgumentOutOfRangeException_WhenNumberIsPositive<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForPositive", () => argument);

            // act & assert
            action.ShouldThrow<TargetInvocationException>()
                .And.InnerException.Should()
                .BeOfType<ArgumentOutOfRangeException>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "NegativeNumbersTestCases")]
        [TestCaseSource(typeof(GuardTestsBase), "ZeroNumbersTestCases")]
        public void ForPositive_DoesNotThrowArgumentOutOfRangeException_WhenNumberIsNegativeOrZero<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForPositive", () => argument);

            // act & assert
            action.ShouldNotThrow<Exception>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "PositiveNumbersTestCases")]
        [TestCaseSource(typeof(GuardTestsBase), "ZeroNumbersTestCases")]
        public void ForPositiveOrZero_ThrowsArgumentOutOfRangeException_WhenNumberIsPositiveOrZero<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForPositiveOrZero", () => argument);

            // act & assert
            action.ShouldThrow<TargetInvocationException>()
                .And.InnerException.Should()
                .BeOfType<ArgumentOutOfRangeException>();
        }

        [TestCaseSource(typeof(GuardTestsBase), "NegativeNumbersTestCases")]
        public void ForPositiveOrZero_DoesNotThrowArgumentOutOfRangeException_WhenNumberIsNegative<TArgument>(TArgument argument)
        {
            // arrange
            Action action = () => InvokeNumericMethod("ForPositiveOrZero", () => argument);

            // act & assert
            action.ShouldNotThrow<Exception>();
        }
    }

    public abstract class GuardTestsBase
    {
        internal const string ArgumentName = "argument";

        internal static readonly object[] NegativeNumbersTestCases =
        {
            new object[] { int.MinValue },
            new object[] { long.MinValue },
            new object[] { short.MinValue },
            new object[] { double.MinValue },
            new object[] { float.MinValue },
            new object[] { decimal.MinValue }
        };

        internal static readonly object[] PositiveNumbersTestCases =
        {
            new object[] { int.MaxValue },
            new object[] { long.MaxValue },
            new object[] { short.MaxValue },
            new object[] { double.MaxValue },
            new object[] { float.MaxValue },
            new object[] { decimal.MaxValue }
        };

        internal static readonly object[] ZeroNumbersTestCases =
        {
            new object[] { 0 },
            new object[] { (long)0 },
            new object[] { (short)0 },
            new object[] { (double)0 },
            new object[] { (float)0 },
            new object[] { (decimal)0 }
        };

        internal static readonly object[] WhenCollectionIsNullOrEmptyTestCases =
        {
            new object[] { null },
            new object[] { new string[] { } }
        };

        internal static void InvokeNumericMethod<TNumericArgument>(string methodName, Expression<Func<TNumericArgument>> argumentExpression)
        {
            var method = typeof(Guard).GetMethod(
                methodName,
                BindingFlags.Static | BindingFlags.Public,
                null,
                new[] { typeof(Expression<Func<TNumericArgument>>) },
                null);

            method.Invoke(null, new object[] { argumentExpression });
        }
    }
}
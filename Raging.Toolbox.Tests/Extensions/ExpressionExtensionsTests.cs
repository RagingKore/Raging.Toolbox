using System;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.Tests.Extensions
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        [Test]
        public void GetVariableName_Should_Return_Variable_Name()
        {
            // arrange
            object myObjectVariable = null;
            Expression<Func<object>> expression = () => myObjectVariable;

            // act
            var result = expression.GetVariableName();

            // assert
            result.Should().Be("myObjectVariable");
        }
    }
}
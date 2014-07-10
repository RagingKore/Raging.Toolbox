using System;
using FluentAssertions;
using NUnit.Framework;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void To_Should_Convert_To_Decimal()
        {
            // arrange
            var rawValue = "10,5";
            var expectedValue = 10.5m;

            // act
            var result = rawValue.To<decimal>();

            // assert
            result.Should().Be(expectedValue);
        }

        [Test]
        public void To_Should_Convert_To_Guid()
        {
            // arrange
            var value = "7c9e6679-7425-40de-944b-e07fc1f90ae7";
            var expectedValue = Guid.Parse(value);

            // act
            var result = value.To<Guid>();

            // assert
            result.Should().Be(expectedValue);
        }

        [Test]
        public void To_Should_Convert_To_DateTime()
        {
            // arrange
            var value = "01-01-2014";
            var expectedValue = DateTime.Parse(value);

            // act
            var result = value.To<DateTime>();

            // assert
            result.Should().Be(expectedValue);
        }
        
        [Test]
        public void To_Should_Convert_To_Enum()
        {
            // arrange
            var value = "Fastest";
            var expectedValue = System.IO.Compression.CompressionLevel.Fastest;

            // act
            var result = value.To<System.IO.Compression.CompressionLevel>();

            // assert
            result.Should().Be(expectedValue);
        }
    }
}
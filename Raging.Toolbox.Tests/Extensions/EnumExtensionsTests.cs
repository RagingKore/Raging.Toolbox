using FluentAssertions;
using NUnit.Framework;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.Tests.Extensions
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        private enum TempEnum
        {
            [System.ComponentModel.Description("Description")]
            A,
            B
        }

        [Test]
        public void Description_Should_Return_Description()
        {
            // act
            var result = TempEnum.A.Description();

            // assert
            result.Should().Be("Description");
        }

        [Test]
        public void Description_Should_Fail_To_Return_Description()
        {
            // act
            var result = TempEnum.B.Description();

            // assert
            result.Should().Be(null);
        }
    }
}
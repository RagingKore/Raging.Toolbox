using NUnit.Framework;

namespace Raging.Toolbox.Testing.FakeItEasy
{
    [TestFixture]
    public abstract class FakeItEasyTestFixtureBase
    {
        [TearDown]
        public void TearDown()
        {
            Auto.ResetAutoFaker();
            Auto.ResetAutoFixture();
        }
    }
}
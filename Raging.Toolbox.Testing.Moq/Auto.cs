using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace Raging.Toolbox.Testing.Moq
{
    public static class Auto
    {
        private static Func<IFixture> factoryFunc = () => ResetFixture();

        public static IFixture Fixture
        {
            get { return factoryFunc(); }
        }

        public static void CustomizeFixture(Func<IFixture> factory)
        {
            Guard.ForNull(() => factory);

            factoryFunc = factory;
        }

        public static IFixture ResetFixture(int recursionDepth = 5)
        {
            var fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());

            if (recursionDepth > 0)
            {
                fixture.Behaviors.Clear();
                fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth));
            }

            return fixture;
        }
    }
}
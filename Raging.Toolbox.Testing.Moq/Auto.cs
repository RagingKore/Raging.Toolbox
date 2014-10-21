using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace Raging.Toolbox.Testing.Moq
{
    public static class Auto
    {
        private const int DefaultRecursionDepth = 5;

        private static Func<IFixture> factoryFunc = () => CreateDefaultFixture();

        public static IFixture Fixture
        {
            get { return factoryFunc(); }
        }

        public static IFixture DefaultFixture
        {
            get
            {
                return CreateDefaultFixture();
            }
        }

        public static void CustomizeFixture(Func<IFixture> factory)
        {
            Guard.Null(() => factory);

            factoryFunc = factory;
        }

        public static void ResetFixture(int recursionDepth = DefaultRecursionDepth)
        {

            factoryFunc = () => CreateDefaultFixture(recursionDepth);
        }

        public static IFixture CreateDefaultFixture(int recursionDepth = DefaultRecursionDepth)
        {
            var fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());

            if(recursionDepth > 0)
            {
                fixture.Behaviors.Clear();
                fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth));
            }

            return fixture;
        }
    }
}
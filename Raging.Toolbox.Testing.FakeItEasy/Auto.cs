using System;
using Autofac.Extras.FakeItEasy;
using Ploeh.AutoFixture;

namespace Raging.Toolbox.Testing.FakeItEasy
{
    /// <summary>
    ///     A helper class that provides ambient instances of AutoFake and AutoFixture.
    /// </summary>
    public sealed class Auto
    {
        private static readonly Func<IFixture> DefaultAutoFixtureInstanceFunc = () => new DefaultFakeItEasyFixture();
        private static readonly Func<AutoFake> DefaultAutoFakerInstanceFunc   = () => new DefaultAutoFake();

        private static AmbientSingleton<IFixture> autoFixtureSingleton = AmbientSingleton.Create(DefaultAutoFixtureInstanceFunc);
        private static AmbientSingleton<AutoFake> autoFakerSingleton   = AmbientSingleton.Create(DefaultAutoFakerInstanceFunc);

        /// <summary>
        ///     Gets the component that provides anonymous object creation services.
        /// </summary>
        /// <value>The AutoFixture component.</value>
        public static IFixture Fixture
        {
            get { return autoFixtureSingleton.Value; }
        }

        /// <summary>
        ///     Gets the component that wrapps around Autofac and Autofac.Extras.FakeItEasy.
        /// </summary>
        /// <value>The AutoFake component.</value>
        public static AutoFake Faker
        {
            get { return autoFakerSingleton.Value; }
        }

        public static IFixture CustomizeAutoFixture(IFixture fixture)
        {
            return (autoFixtureSingleton = AmbientSingleton.Create(fixture)).Value;
        }

        public static IFixture ResetAutoFixture()
        {
            return (autoFixtureSingleton = AmbientSingleton.Create(DefaultAutoFixtureInstanceFunc)).Value;
        }

        public static AutoFake CustomizeAutoFaker(AutoFake autoFaker)
        {
            return (autoFakerSingleton = AmbientSingleton.Create(autoFaker)).Value;
        }

        public static AutoFake ResetAutoFaker()
        {
            return (autoFakerSingleton = AmbientSingleton.Create(DefaultAutoFakerInstanceFunc)).Value;
        }
    }
}
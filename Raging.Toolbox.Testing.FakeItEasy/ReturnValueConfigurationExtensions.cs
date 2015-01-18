using System.Threading.Tasks;
using FakeItEasy;
using FakeItEasy.Configuration;

namespace Raging.Toolbox.Testing.FakeItEasy
{
    public static class ReturnValueConfigurationExtensions
    {
        /// <summary>
        ///     An IReturnValueConfiguration&lt;TValue&gt; extension method 
        ///     that configures a return of a new instance of TValue.
        /// </summary>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="configuration">The configuration to act on.</param>
        /// <returns>An IAfterCallSpecifiedWithOutAndRefParametersConfiguration.</returns>
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsDefault<TValue>(this IReturnValueConfiguration<TValue> configuration)
            where TValue : new()
        {
            return configuration.Returns(new TValue());
        }

        /// <summary>
        ///     An IReturnValueConfiguration&lt;Task&lt;TValue&gt;&gt; extension method
        ///     that configures a return of a new instance of TValue, from a Task call.
        /// </summary>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="configuration">The configuration to act on.</param>
        /// <returns>An IAfterCallSpecifiedWithOutAndRefParametersConfiguration.</returns>
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsDefault<TValue>(this IReturnValueConfiguration<Task<TValue>> configuration)
            where TValue : new()
        {
            return configuration.Returns(Task.FromResult(new TValue()));
        }

        /// <summary>
        ///     An IReturnValueConfiguration&lt;TValue&gt; extension method 
        ///     that configures a lazy return of a new instance of TValue.
        /// </summary>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="configuration">The configuration to act on.</param>
        /// <returns>An IAfterCallSpecifiedWithOutAndRefParametersConfiguration.</returns>
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsDefaultLazily<TValue>(this IReturnValueConfiguration<TValue> configuration)
            where TValue : new()
        {
            return configuration.ReturnsLazily(() => new TValue());
        }

        /// <summary>
        ///     An IReturnValueConfiguration&lt;Task&lt;TValue&gt;&gt; extension method
        ///     that configures a lazy return of a new instance of TValue, from a Task call.
        /// </summary>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="configuration">The configuration to act on.</param>
        /// <returns>An IAfterCallSpecifiedWithOutAndRefParametersConfiguration.</returns>
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsDefaultLazily<TValue>(this IReturnValueConfiguration<Task<TValue>> configuration)
            where TValue : new()
        {
            return configuration.ReturnsLazily(() => new TValue());
        }

        /// <summary>
        ///     An IReturnValueConfiguration&lt;TValue&gt; extension method that configures
        ///     a lazy return of an automatically resolved instance of TValue, via AutoFake.
        /// </summary>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="configuration">The configuration to act on.</param>
        /// <returns>An IAfterCallSpecifiedWithOutAndRefParametersConfiguration.</returns>
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsAutoFake<TValue>(this IReturnValueConfiguration<TValue> configuration)
        {
            return configuration.ReturnsLazily(() => Auto.Faker.Resolve<TValue>());
        }

        /// <summary>
        ///     An IReturnValueConfiguration&lt;Task&lt;TValue&gt;&gt; extension method that configures
        ///     a lazy return of an automatically resolved instance of TValue, via AutoFake, from a Task call.
        /// </summary>
        /// <tparam name="TValue">Type of the value.</tparam>
        /// <param name="configuration">The configuration to act on.</param>
        /// <returns>An IAfterCallSpecifiedWithOutAndRefParametersConfiguration.</returns>
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsAutoFake<TValue>(this IReturnValueConfiguration<Task<TValue>> configuration)
        {
            return configuration.ReturnsLazily(() => Auto.Faker.Resolve<TValue>());
        }
    }
}

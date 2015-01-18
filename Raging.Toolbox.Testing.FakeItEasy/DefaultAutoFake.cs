using System;
using Autofac;
using Autofac.Extras.FakeItEasy;

namespace Raging.Toolbox.Testing.FakeItEasy
{
    /// <summary>
    ///     Wrapper around <see cref="N:Autofac"/> and <see cref="N:Autofac.Extras.FakeItEasy"/>
    /// </summary>
    public class DefaultAutoFake : AutoFake
    {
        public DefaultAutoFake(bool strict = false, bool callsBaseMethods = false, bool callsDoNothing = false, Action<object> onFakeCreated = null, ContainerBuilder builder = null)
            : base(strict, callsBaseMethods, callsDoNothing, onFakeCreated, builder) { }
    }
}
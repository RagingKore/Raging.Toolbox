using System;
using System.Collections.Generic;

namespace Raging.Toolbox.DependencyResolution
{
    public interface IDependencyResolver
    {
        TService Resolve<TService>() where TService : class;

        TService Resolve<TService>(params object[] parameters) where TService : class;

        TService ResolveNamed<TService>(string name) where TService : class;

        TService ResolveNamed<TService>(string name, params object[] parameters) where TService : class;

        IEnumerable<TService> ResolveAll<TService>() where TService : class;

        object Resolve(Type serviceType);

        object Resolve(Type serviceType, params object[] parameters);

        object ResolveNamed(Type serviceType, string name);

        object ResolveNamed(Type serviceType, string name, params object[] parameters);

        IEnumerable<object> ResolveAll(Type serviceType);

        TService ResolveAs<TService>(Type serviceBaseType);

        TService ResolveNamedAs<TService>(Type serviceBaseType, string name);

        TService ResolveNamedAs<TService>(Type serviceBaseType, string name, params object[] parameters);

        TService ResolveAs<TService>(Type serviceBaseType, params object[] parameters);

        IEnumerable<TService> ResolveAllAs<TService>(Type serviceBaseType);
    }
}
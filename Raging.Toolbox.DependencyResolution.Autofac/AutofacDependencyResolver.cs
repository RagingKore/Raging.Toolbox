using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.DependencyResolution.Autofac
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope container;

        public AutofacDependencyResolver(ILifetimeScope container)
        {
            if(container == null) throw new ArgumentNullException("container");

            this.container = container;
        }

        public object Resolve(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public object Resolve(Type serviceType, params object[] parameters)
        {
            return this.container.Resolve(serviceType, parameters.Select((p, i) => new PositionalParameter(i, p)));
        }

        public object Resolve(Type serviceType, string named)
        {
            return this.container.ResolveNamed(named, serviceType);
        }

        public TService Resolve<TService>() where TService : class
        {
            return this.container.Resolve<TService>();
        }

        public TService Resolve<TService>(params object[] parameters) where TService : class
        {
            return this.container.Resolve<TService>(parameters.Select((p, i) => new PositionalParameter(i, p)));
        }

        public TService Resolve<TService>(string named) where TService : class
        {
            return this.container.ResolveNamed<TService>(named);
        }
        
        public IEnumerable<TService> ResolveAll<TService>() where TService : class
        {
            return this.container.ResolveAll<TService>().EmptyIfNull();
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).EmptyIfNull();
        }

        public TService ResolveNamed<TService>(string name) where TService : class
        {
            return this.container.ResolveNamed<TService>(name);
        }

        public TService ResolveNamed<TService>(string name, params object[] parameters) where TService : class
        {
            return this.container.ResolveNamed<TService>(name, parameters.Select((p, i) => new PositionalParameter(i, p)));
        }

        public object ResolveNamed(Type serviceType, string name)
        {
            return this.container.ResolveNamed(name, serviceType);
        }

        public object ResolveNamed(Type serviceType, string name, params object[] parameters)
        {
            return this.container.ResolveNamed(name, serviceType, parameters.Select((p, i) => new PositionalParameter(i, p)));
        }

        public TService ResolveAs<TService>(Type serviceBaseType)
        {
            return (TService)this.container.Resolve(serviceBaseType);
        }

        public TService ResolveNamedAs<TService>(Type serviceBaseType, string name)
        {
            return (TService)this.container.ResolveNamed(name, serviceBaseType);
        }

        public TService ResolveNamedAs<TService>(Type serviceBaseType, string name, params object[] parameters)
        {
            return (TService)this.container.ResolveNamed(name, serviceBaseType, parameters.Select((p, i) => new PositionalParameter(i, p)));
        }

        public TService ResolveAs<TService>(Type serviceBaseType, params object[] parameters)
        {
            return (TService)this.container.Resolve(serviceBaseType, parameters.Select((p, i) => new PositionalParameter(i, p)));
        }

        public IEnumerable<TService> ResolveAllAs<TService>(Type serviceBaseType)
        {
            return this.container.ResolveAll(serviceBaseType).EmptyIfNull().Cast<TService>();
        }
    }
}
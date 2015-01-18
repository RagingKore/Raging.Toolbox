using Autofac;

namespace Raging.Toolbox.DependencyResolution.Autofac
{
    public class AutofacDependencyResolverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // register dependency resolver
            builder
                .Register<IDependencyResolver, AutofacDependencyResolver>()
                .InstancePerLifetimeScope();
        }
    }
}
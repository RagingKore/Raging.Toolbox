using System;
using System.Configuration;
using System.Linq;
using Autofac;
using Raging.Toolbox.Extensions;
using Rebus;
using Rebus.Configuration;
using Rebus.Logging;
using Tru.Common.Rebus.Configuration;

namespace Tru.Common.Rebus.Autofac
{
    public class MultiBusInstallationModule : Module
    {
        private readonly Action<LoggingConfigurer> configureLogging = configurer => configurer.ColoredConsole(LogLevel.Info);
        private readonly Type eventMessageInterfaceMarkerType;

        public MultiBusInstallationModule() { }

        public MultiBusInstallationModule(Action<LoggingConfigurer> configureLogging, Type eventMessageInterfaceMarkerType)
        {
            this.configureLogging = configureLogging;
            this.eventMessageInterfaceMarkerType = eventMessageInterfaceMarkerType;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // load configuration section so we can fail fast
            var multiBusConfiguration = (MultiBusConfigurationSection)ConfigurationManager.GetSection("multiBus");

            builder.RegisterInstance(multiBusConfiguration);

            // register all referenced handlers
            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetReferencedAssemblies().ToArray())
                .Where(typeof(IHandleMessages).IsAssignableFrom)
                .Where(type => type.Namespace != null && !type.Namespace.StartsWith("Rebus"))
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            // register all buses  
            foreach (var busConfiguration in multiBusConfiguration.BusConfigurations)
            {
                multiBusConfiguration.SetBusConfigurationDefaults(busConfiguration);
                builder.RegisterModule(
                    new BusInstallationModule(
                        busConfiguration, 
                        this.configureLogging, 
                        this.eventMessageInterfaceMarkerType));
            }
        }
    }
}
using System;
using System.Configuration;
using System.Linq;
using Autofac;
using Raging.Toolbox.Extensions;
using Rebus;
using Rebus.Autofac;
using Rebus.Configuration;
using Rebus.Transports.Msmq;
using Tru.Common.Rebus.Configuration;

namespace Tru.Common.Rebus.Autofac
{
    public class BusInstallationModule : Module
    {
        private readonly RebusConfigurationElement configuration;
        private readonly Action<LoggingConfigurer> configureLogging;
        private readonly Type eventMessageInterfaceMarkerType;
        private string[] messagesAssemblyNames;

        public BusInstallationModule(
            RebusConfigurationElement configuration, 
            Action<LoggingConfigurer> configureLogging, 
            Type eventMessageInterfaceMarkerType = null)
        {
            this.configuration = configuration;
            this.configureLogging = configureLogging;
            this.eventMessageInterfaceMarkerType = eventMessageInterfaceMarkerType;

            // TODO: Move functionality to configuration 
            this.configuration.Name = configuration.Name.IsNullOrWhiteSpace()
                ? configuration.InputQueue
                : configuration.Name;
            this.configuration.InputQueue = configuration.InputQueue.IsNullOrWhiteSpace()
                ? configuration.Name
                : configuration.InputQueue;
            this.configuration.ErrorQueue = configuration.ErrorQueue.IsNullOrWhiteSpace()
                ? configuration.InputQueue + ".error"
                : configuration.ErrorQueue;
            this.configuration.AuditQueue = configuration.AuditQueue.IsNullOrWhiteSpace()
                ? configuration.InputQueue + ".audit"
                : configuration.AuditQueue;
        }

        private string[] MessagesAssemblyNames
        {
            get
            {
                return this.messagesAssemblyNames 
                    ?? (this.messagesAssemblyNames = this.configuration.MappingsCollection
                        .Where(m => m.IsAssemblyName)
                        .Select(m => m.Messages)
                        .ToArray());
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            // register bus
            builder
                .Register(context =>
                    this.CreateBus(new AutofacContainerAdapter(context.Resolve<Func<IContainer>>()())))
                .Named<IBus>(this.configuration.Name)
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .SingleInstance();
        }

        private IBus CreateBus(IContainerAdapter containerAdapter)
        {
            var startableBus = global::Rebus.Configuration.Configure.With(containerAdapter)
                .Logging(this.configureLogging)
                .Transport(t => t.UseMsmq(this.configuration.InputQueue, this.configuration.ErrorQueue))
                .MessageOwnership(m => m.FromRebusConfigurationElement(this.configuration))
                .Subscriptions(s => s
                    .StoreInSqlServer(
                        this.configuration.SqlServerSubscriptionsStorageConfiguration.NameOrConnectionString,
                        this.configuration.SqlServerSubscriptionsStorageConfiguration.Table)
                    .EnsureTableIsCreated())
                .Sagas(s => s
                    .StoreInSqlServer(
                        this.configuration.SqlServerSagaStorageConfiguration.NameOrConnectionString,
                        this.configuration.SqlServerSagaStorageConfiguration.Table,
                        this.configuration.SqlServerSagaStorageConfiguration.IndexTable)
                    .DoNotIndexNullProperties()
                    .EnsureTablesAreCreated())
                .Timeouts(t => t
                    .StoreInSqlServer(
                        ConnectionStringUtil.GetConnectionStringToUse(this.configuration.SqlServerTimeoutsManagerConfiguration.NameOrConnectionString),
                        this.configuration.SqlServerTimeoutsManagerConfiguration.Table)
                    .EnsureTableIsCreated())
                .CreateBus();

            var bus = !this.configuration.Workers.HasValue
                ? startableBus.Start()
                : startableBus.Start(this.configuration.Workers.Value);

            if(this.eventMessageInterfaceMarkerType == null) 
                return bus;

            // auto subscribe all messages in the mappings that implement the interface marker type
            bus.SubscribeMessagesAssignableFrom(
                this.eventMessageInterfaceMarkerType, 
                ns => ns != null && ns.StartsWithAny(this.MessagesAssemblyNames));

            return bus;
        }

        internal static class ConnectionStringUtil
        {
            internal static string GetConnectionStringToUse(string connectionStringOrConnectionStringName)
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringOrConnectionStringName];
                return connectionStringSettings != null ? connectionStringSettings.ConnectionString : connectionStringOrConnectionStringName;
            }
        }
    }
}
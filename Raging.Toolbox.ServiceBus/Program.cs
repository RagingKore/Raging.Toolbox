using System;
using Autofac;
using Rebus;
using Rebus.Configuration;
using Rebus.Autofac;
using Rebus.Transports.Msmq;
using Topshelf;
using Topshelf.Autofac;

namespace Raging.Toolbox.ServiceBus
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.UseAutofacContainer(GetContainer());

                hostConfigurator.Service<RebusService>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsingAutofacContainer();
                    serviceConfigurator.WhenStarted(rebusService => rebusService.Start());
                    serviceConfigurator.WhenStopped(rebusService => rebusService.Stop());
                });

                hostConfigurator.SetServiceName("RagingToolBoxServiceBus");
                hostConfigurator.SetDisplayName("Raging ToolBox ServiceBus");

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.StartAutomatically();
            });

            Console.ReadLine();
        }

        private static IContainer GetContainer()
        {
            // create container builder
            var builder = new ContainerBuilder();



            // return container          
            return builder.Build();
        }
    }

    public class RebusService
    {
        private readonly IContainer container;

        public RebusService(IContainer container)
        {
            this.container = container;
        }

        public bool Start()
        {
            var bus = Configure
               .With(new AutofacContainerAdapter(this.container))
               //.Logging(l => l.)
               .Transport(t => t.UseMsmqAndGetInputQueueNameFromAppConfig())
               .MessageOwnership(d => d.FromRebusConfigurationSection())
               .Serialization(s => s.UseJsonSerializer())
               .CreateBus()
               .Start();


            
            return true;
        }

        public bool Stop()
        {
            return true;
        }

    }
}

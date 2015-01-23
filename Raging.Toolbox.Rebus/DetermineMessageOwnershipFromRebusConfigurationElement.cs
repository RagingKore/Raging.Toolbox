using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Raging.Toolbox.Extensions;
using Rebus;
using Rebus.Configuration;
using Rebus.Logging;
using Tru.Common.Rebus.Configuration;

namespace Tru.Common.Rebus
{
    public class DetermineMessageOwnershipFromRebusConfigurationElement : IDetermineMessageOwnership
    {
        private static ILog log;

        private readonly ConcurrentDictionary<Type, string> messageEndpointMappings = new ConcurrentDictionary<Type, string>();

        static DetermineMessageOwnershipFromRebusConfigurationElement()
        {
            RebusLoggerFactory.Changed += f => log = f.GetCurrentClassLogger();
        }

        public DetermineMessageOwnershipFromRebusConfigurationElement(RebusConfigurationElement configuration)
        {
            this.PopulateMappings(configuration);
        }

        public string GetEndpointFor(Type messageType)
        {
            string endpoint;

            if (this.messageEndpointMappings.TryGetValue(messageType, out endpoint))
                return endpoint;

            var errorMessage = @"
                Could not find an endpoint mapping for the message type {0}. 
                Please ensure that you have mapped all message types, you wish to either Send or
                Subscribe to, to an endpoint - a 'message owner' if you will.";

            throw new InvalidOperationException(errorMessage.FormatWith(messageType));
        }

        private static Assembly LoadAssembly(string assemblyName)
        {
            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception e)
            {
                throw new ConfigurationException(
                    @"
Something went wrong when trying to load message types from assembly {0}
{1}
For this to work, Rebus needs access to an assembly with one of the following filenames:
    {0}.dll
    {0}.exe
",
                    assemblyName,
                    e);
            }
        }

        private void Map(Type messageType, string endpoint)
        {
            log.Info("    {0} -> {1}", messageType, endpoint);

            if (this.messageEndpointMappings.ContainsKey(messageType))
            {
                log.Warn(
                    "    ({0} -> {1} overridden by -> {2})",
                    messageType,
                    this.messageEndpointMappings[messageType],
                    endpoint);
            }

            this.messageEndpointMappings[messageType] = endpoint;
        }

        private static readonly Func<Type, bool> DefaultMessageTypeFilter = t => t.IsPublic && t.IsClass && !t.IsAbstract;

        private void PopulateMappings(RebusConfigurationElement configuration)
        {
            // ensure that all assembly mappings are processed first,
            // so that explicit type mappings will take precendence
            var mappingElements = configuration.MappingsCollection
                .OrderBy(c => !c.IsAssemblyName);

            foreach (var element in mappingElements)
            {
                if (element.IsAssemblyName)
                {
                    var assemblyName = element.Messages;

                    log.Info("Mapping assembly: {0}", assemblyName);

                    var assembly = LoadAssembly(assemblyName);

                    foreach (var type in assembly.GetTypes().Where(DefaultMessageTypeFilter))
                    {
                        this.Map(type, element.Endpoint);
                    }
                }
                else
                {
                    var typeName = element.Messages;

                    log.Info("Mapping type: {0}", typeName);

                    var messageType = Type.GetType(typeName);

                    if (messageType == null || DefaultMessageTypeFilter(messageType))
                    {
                        throw new ConfigurationException(
                            @"Could not find the message type {0}. If you choose to map a specific message type,
please ensure that the type is available for Rebus to load. This requires that the
assembly can be found in Rebus' current runtime directory, that the type is available,
and that any (of the optional) version and key requirements are matched",
                            typeName);
                    }

                    this.Map(messageType, element.Endpoint);
                }
            }
        }
    }
}

using System.Configuration;
using Rebus.Configuration;
using Rebus.Shared;

namespace Tru.Common.Rebus.Configuration
{
    public class RebusConfigurationElement : ConfigurationElement
    {
        /// <summary>
        ///     Gets or sets the name for the bus and serves as default input queue and queue namespace for error and audit queues.
        /// </summary>
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        ///     Gets this endpoint's address (can be used in cases where e.g. an IP should be used instead of the machine name)
        /// </summary>
        [ConfigurationProperty("address")]
        public string Address
        {
            get { return (string)this["address"]; }
            set { this["address"] = value; }
        }

        [ConfigurationProperty("enableAuditing")]
        public bool EnableAuditing
        {
            get { return (bool)this["enableAuditing"]; }
            set { this["enableAuditing"] = value; }
        }

        /// <summary>
        ///     Configures the name of a queue to which all successfully processed messages will be copied upon completion, and to
        ///     which all published messages will be copied when they are published. Messages sent to this queue will have had the
        ///     <see cref="Headers.AuditReason"/> header added with a value of either <see cref="Headers.AuditReasons.Handled"/> or
        ///     <see cref="Headers.AuditReasons.Published"/>, depending on the reason why the message was copied.
        /// </summary>
        [ConfigurationProperty("auditQueue")]
        public string AuditQueue
        {
            get { return (string)this["auditQueue"]; }
            set { this["auditQueue"] = value; }
        }

        /// <summary>
        ///     Gets the error queue name.
        /// </summary>
        [ConfigurationProperty("errorQueue")]
        public string ErrorQueue
        {
            get { return (string)this["errorQueue"]; }
            set { this["errorQueue"] = value; }
        }

        /// <summary>
        ///     Gets the input queue name.
        /// </summary>
        [ConfigurationProperty("inputQueue")]
        public string InputQueue
        {
            get { return (string)this["inputQueue"]; }
            set { this["inputQueue"] = value; }
        }

        /// <summary>
        ///     Configures how many times a message should be delivered with error before it is moved to the error queue.
        /// </summary>
        [ConfigurationProperty("maxRetries")]
        public int? MaxRetries
        {
            get { return (int?)this["maxRetries"]; }
            set { this["maxRetries"] = value; }
        }

        /// <summary>
        ///     Gets the number of workers that should be started in this endpoint.
        /// </summary>
        [ConfigurationProperty("workers")]
        public int? Workers
        {
            get { return (int?)this["workers"]; }
            set { this["workers"] = value; }
        }

        [ConfigurationProperty("setCurrentPrincipal")]
        public bool? SetCurrentPrincipal
        {
            get { return (bool?)this["setCurrentPrincipal"]; }
            set { this["setCurrentPrincipal"] = value; }
        }

        [ConfigurationProperty("latencyBackoffMilliseconds")]
        public int? LatencyBackoffMilliseconds
        {
            get { return (int?)this["latencyBackoffMilliseconds"]; }
            set { this["latencyBackoffMilliseconds"] = value; }
        }

        [ConfigurationProperty("compressMessages")]
        public bool? CompressMessages
        {
            get { return (bool?)this["compressMessages"]; }
            set { this["compressMessages"] = value; }
        }

        [ConfigurationProperty("compressionThresholdBytes")]
        public int? CompressionThreshold
        {
            get { return (int?)this["compressionThresholdBytes"]; }
            set { this["compressionThresholdBytes"] = value; }
        }

        [ConfigurationProperty("encryptMessages")]
        public bool? EncryptMessages
        {
            get { return (bool?)this["encryptMessages"]; }
            set { this["encryptMessages"] = value; }
        }

        [ConfigurationProperty("encryptionKey")]
        public string EncryptionKey
        {
            get { return (string)this["encryptionKey"]; }
            set { this["encryptionKey"] = value; }
        }

        /// <summary>
        /// Gets the mapping configuration section.
        /// </summary>
        [ConfigurationProperty("endpoints")]
        public MappingsCollection MappingsCollection
        {
            get { return (MappingsCollection)this["endpoints"]; }
            set { this["endpoints"] = value; }
        }

        [ConfigurationProperty("sqlServerSubscriptionStorage")]
        public SqlServerSubscriptionsStorageConfigurationElement SqlServerSubscriptionsStorageConfiguration
        {
            get { return (SqlServerSubscriptionsStorageConfigurationElement)this["sqlServerSubscriptionStorage"]; }
            set { this["sqlServerSubscriptionStorage"] = value; }
        }

        [ConfigurationProperty("sqlServerSagaStorage")]
        public SqlServerSagaStorageConfigurationElement SqlServerSagaStorageConfiguration
        {
            get { return (SqlServerSagaStorageConfigurationElement)this["sqlServerSagaStorage"]; }
            set { this["sqlServerSagaStorage"] = value; }
        }

        [ConfigurationProperty("sqlServerTimeouts")]
        public SqlServerTimeoutsConfigurationElement SqlServerTimeoutsManagerConfiguration
        {
            get { return (SqlServerTimeoutsConfigurationElement)this["sqlServerTimeouts"]; }
            set { this["sqlServerTimeouts"] = value; }
        }

        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
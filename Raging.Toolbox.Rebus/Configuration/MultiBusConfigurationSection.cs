using System.Configuration;

namespace Tru.Common.Rebus.Configuration
{
    public class MultiBusConfigurationSection : ConfigurationSection
    {
        // <multiBus>

        /// <summary>
        ///     Configures how many times a message should be delivered with error before it is moved to the error queue.
        /// </summary>
        [ConfigurationProperty("maxRetries", DefaultValue = 3)]
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

        [ConfigurationProperty("latencyBackoffMilliseconds", DefaultValue = 250)]
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

        [ConfigurationProperty("rebusConfigurations", IsRequired = true)]
        public RebusConfigurationElementCollection BusConfigurations
        {
            get { return (RebusConfigurationElementCollection)this["rebusConfigurations"]; }
            set { this["rebusConfigurations"] = value; }
        }

        public RebusConfigurationElement SetBusConfigurationDefaults(RebusConfigurationElement configuration)
        {
            if(configuration.MaxRetries == null && this.MaxRetries != null)
                configuration.MaxRetries = this.MaxRetries;

            if(configuration.Workers == null && this.Workers != null)
                configuration.Workers = this.Workers;

            if(configuration.SetCurrentPrincipal == null && this.SetCurrentPrincipal != null)
                configuration.SetCurrentPrincipal = this.SetCurrentPrincipal;

            if(configuration.LatencyBackoffMilliseconds == null && this.LatencyBackoffMilliseconds != null)
                configuration.LatencyBackoffMilliseconds = this.LatencyBackoffMilliseconds;

            if(configuration.CompressMessages == null && this.CompressMessages != null)
                configuration.CompressMessages = this.CompressMessages;

            if(configuration.CompressionThreshold == null && this.CompressionThreshold != null)
                configuration.CompressionThreshold = this.CompressionThreshold;

            if(configuration.EncryptMessages == null && this.EncryptMessages != null)
                configuration.EncryptMessages = this.EncryptMessages;

            if(configuration.EncryptMessages == null && this.EncryptMessages != null)
                configuration.EncryptionKey = this.EncryptionKey;

            //if (configuration.SqlServerSubscriptionsStorageConfiguration == null && this.SqlServerSubscriptionsStorageConfiguration != null)
            configuration.SqlServerSubscriptionsStorageConfiguration = this.SqlServerSubscriptionsStorageConfiguration;

            //if (configuration.SqlServerSagaStorageConfiguration == null && this.SqlServerSagaStorageConfiguration != null)
            configuration.SqlServerSagaStorageConfiguration = this.SqlServerSagaStorageConfiguration;

            //if (configuration.SqlServerTimeoutsManagerConfiguration == null && this.SqlServerTimeoutsManagerConfiguration != null)
            configuration.SqlServerTimeoutsManagerConfiguration = this.SqlServerTimeoutsManagerConfiguration;

            return configuration;
        }
    }
}
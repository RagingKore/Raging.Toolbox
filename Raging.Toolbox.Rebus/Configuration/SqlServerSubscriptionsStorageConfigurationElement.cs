using System.Configuration;

namespace Tru.Common.Rebus.Configuration
{
    public class SqlServerSubscriptionsStorageConfigurationElement : ConfigurationElement
    {
        // <sqlServerSubscriptionStorage nameOrConnectionString="" table="Rebus.Subscriptions" ensureTableCreated="true" />

        [ConfigurationProperty("nameOrConnectionString", IsRequired = true)]
        public string NameOrConnectionString
        {
            get { return (string)this["nameOrConnectionString"]; }
            set { this["nameOrConnectionString"] = value; }
        }

        [ConfigurationProperty("table", DefaultValue = "Rebus.Subscriptions")]
        public string Table
        {
            get { return (string)this["table"]; }
            set { this["table"] = value; }
        }

        [ConfigurationProperty("ensureTableCreated", DefaultValue = true)]
        public bool EnsureTableCreated
        {
            get { return (bool)this["ensureTableCreated"]; }
            set { this["ensureTableCreated"] = value; }
        }
    }
}
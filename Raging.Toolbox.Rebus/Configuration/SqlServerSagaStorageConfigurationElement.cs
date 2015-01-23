using System.Configuration;

namespace Tru.Common.Rebus.Configuration
{
    public class SqlServerSagaStorageConfigurationElement : ConfigurationElement
    {
        // <sqlServerSagaStorage nameOrConnectionString="" table="Rebus.Sagas" indexTable="Rebus.Sagas.Index" ensureTablesCreated="true" />

        [ConfigurationProperty("nameOrConnectionString", IsRequired = true)]
        public string NameOrConnectionString
        {
            get { return (string)this["nameOrConnectionString"]; }
            set { this["nameOrConnectionString"] = value; }
        }

        [ConfigurationProperty("table", DefaultValue = "Rebus.Sagas")]
        public string Table
        {
            get { return (string)this["table"]; }
            set { this["table"] = value; }
        }

        [ConfigurationProperty("indexTable", DefaultValue = "Rebus.Sagas.Index")]
        public string IndexTable
        {
            get { return (string)this["indexTable"]; }
            set { this["indexTable"] = value; }
        }

        [ConfigurationProperty("ensureTablesCreated", DefaultValue = true)]
        public bool EnsureTablesCreated
        {
            get { return (bool)this["ensureTablesCreated"]; }
            set { this["ensureTablesCreated"] = value; }
        }
    }
}
using System.Configuration;

namespace Tru.Common.Rebus.Configuration
{
    public class SqlServerTimeoutsConfigurationElement : ConfigurationElement
    {
        // <sqlServerTimeoutManager nameOrConnectionString="" table="Rebus.Timeouts" />

        [ConfigurationProperty("nameOrConnectionString", IsRequired = true)]
        public string NameOrConnectionString
        {
            get { return (string)this["nameOrConnectionString"]; }
            set { this["nameOrConnectionString"] = value; }
        }

        [ConfigurationProperty("table", DefaultValue = "Rebus.Timeouts")]
        public string Table
        {
            get { return (string)this["table"]; }
            set { this["table"] = value; }
        }
    }
}
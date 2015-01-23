using System.Configuration;

namespace Tru.Common.Rebus.Configuration
{
    [ConfigurationCollection(typeof(RebusConfigurationElement), AddItemName = "rebus", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class RebusConfigurationElementCollection : GenericConfigurationElementCollection<RebusConfigurationElement>
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            var configuration = (RebusConfigurationElement)element;
            return configuration.Name ?? configuration.InputQueue;
        }
    }
}
using Rebus.Configuration;
using Tru.Common.Rebus.Configuration;

namespace Tru.Common.Rebus
{
    public static class RebusRouterConfigurerExtensions
    {
        public static void FromRebusConfigurationElement(this RebusRoutingConfigurer configurer, RebusConfigurationElement configuration)
        {
            configurer.Use(new DetermineMessageOwnershipFromRebusConfigurationElement(configuration));
        }
    }
}
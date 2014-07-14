using System;
using Raging.Toolbox.Extensions;

namespace Raging.Toolbox.Configuration
{
    public static class ConfigurationManager
    {
        public static T GetSection<T>(string name)
        {
            Check.ForNullOrWhiteSpace(() => name);

            var section = System.Configuration.ConfigurationManager.GetSection(name);

            if(section.IsNull())
                throw new Exception();

            return (T) section;
        }
    }
}
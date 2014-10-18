using System;
using System.Text.RegularExpressions;

namespace Raging.Toolbox.Configuration
{
    public static class ConfigurationManager
    {
        private const string ConfigurationNameByConventionPattern = @"I([a-z0-9\-]+)Config";

        public static T GetSection<T>(string name) 
        {
            Guard.ForNullOrWhiteSpace(() => name);

            return (T)System.Configuration.ConfigurationManager.GetSection(name);
        }

        public static T GetSection<T>() 
        {
            var type = typeof(T);

            if (!type.IsInterface)
                throw new ArgumentException();
            
            var match = Regex.Match(
                type.Name, 
                ConfigurationNameByConventionPattern, 
                RegexOptions.IgnoreCase);

            var nameByConvention = match.Success
                ? match.Groups[1].Value
                : null;

            return GetSection<T>(nameByConvention);
        }
    }
}
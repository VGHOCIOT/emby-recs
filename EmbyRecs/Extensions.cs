using System.Collections.Generic;
using MediaBrowser.Common.Configuration;

namespace EmbyRecs
{
    public static class ConfigurationExtension
    {
        public static EmbyRecsOptions GetEmbyRecsOptions(this IConfigurationManager manager)
        {
            return manager.GetConfiguration<EmbyRecsOptions>("embyrecs");
        }

        public static void SaveEmbyRecsOptions(this IConfigurationManager manager, EmbyRecsOptions options)
        {
            manager.SaveConfiguration("embyrecs", options);
        }
    }

    public class EmbyRecsOptionsFactory : IConfigurationFactory
    {
        public IEnumerable<ConfigurationStore> GetConfigurations()
        {
            return new List<ConfigurationStore>
            {
                new ConfigurationStore
                {
                    Key = "embyrecs",
                    ConfigurationType = typeof(EmbyRecsOptions)
                }
            };
        }
    }
}
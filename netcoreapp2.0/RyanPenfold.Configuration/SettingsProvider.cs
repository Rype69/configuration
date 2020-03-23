using System.IO;
using Microsoft.Extensions.Configuration;

namespace RyanPenfold.Configuration
{
    public class SettingsProvider<T> where T : new()
    {
        private static IConfigurationBuilder _configurationBuilder;

        private static IConfigurationRoot _configurationRoot;

        private static T _configurationSection;

        /// <summary>
        /// Gets or sets a value indicating whether configuration can be
        /// reloaded during the running of the application
        /// </summary>
        public static bool AllowReload { get; set; } = true;

        private static IConfigurationBuilder ConfigurationBuilder
        {
            get
            {
                if (_configurationBuilder == null || AllowReload)
                {
                    // Build an instance of ConfigurationSection from the json file
                    _configurationBuilder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(ConfigurationFileName);
                }

                return _configurationBuilder;
            }
        }

        public static string ConfigurationFileName { get; set; } = "appsettings.json";

        public static IConfigurationRoot ConfigurationRoot
        {
            get
            {
                if (_configurationRoot == null || AllowReload)
                {
                    _configurationRoot = ConfigurationBuilder.Build();
                }

                return _configurationRoot;
            }
            private set => _configurationRoot = value;
        }

        public static T GetSection(string sectionName)
        {
            if (_configurationSection == null || AllowReload)
            {
                ConfigurationRoot = ConfigurationBuilder.Build();

                if (_configurationSection == null || AllowReload)
                {
                    _configurationSection = new T();
                }

                ConfigurationRoot.GetSection(sectionName).Bind(_configurationSection);
            }

            return _configurationSection;
        }
    }
}

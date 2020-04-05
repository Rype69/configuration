using System.Collections.Generic;
using System.Configuration;

namespace RyanPenfold.Configuration
{
    public class AppSettings
    {
        private static AppSettings _instance;

        private AppSettings()
        {
        }

        private static AppSettings Instance
        {
            get { return _instance ??= new AppSettings(); }
        }

        public string this[string key]
        {
            get
            {
                var appSettings = SettingsProvider<Dictionary<string, string>>.GetSection("AppSettings");
                if (appSettings == null)
                    throw new ConfigurationErrorsException("AppSettings section not found.");

                return appSettings[key];
            }
        }

        public static string Get(string key)
        {
            return Instance[key];
        }
    }
}

using System.Collections.Specialized;
using System.Configuration;

namespace RyanPenfold.Configuration
{
    public class AppSettings
    {
        public string this[string key]
        {
            get
            {
                var appSettings = SettingsProvider<NameValueCollection>.GetSection("appSettings");
                if (appSettings == null)
                    throw new ConfigurationErrorsException("appSettings section not found.");

                return appSettings[key];
            }
        }

    }
}

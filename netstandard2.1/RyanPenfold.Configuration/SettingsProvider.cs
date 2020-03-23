using Microsoft.Extensions.Configuration;

namespace RyanPenfold.Configuration
{
    public class SettingsProvider
    {
        public static IConfiguration Configuration { get; set; }

        public static string ConfigurationFileName { get; set; } = "appsettings.json";
    }
}

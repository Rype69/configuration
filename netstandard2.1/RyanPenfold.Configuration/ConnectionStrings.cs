using System.Collections.Generic;

namespace RyanPenfold.Configuration
{
    public class ConnectionStrings
    {
        private static ConnectionStrings _instance;

        private ConnectionStrings()
        {
        }

        private static ConnectionStrings Instance
        {
            get { return _instance ??= new ConnectionStrings(); }
        }

        public string this[string key]
        {
            get
            {
                var connectionStrings = SettingsProvider<Dictionary<string, string>>.GetSection("ConnectionStrings");
                var rtn = connectionStrings[key];
                return rtn;
            }
        }

        public static string Get(string key)
        {
            return Instance[key];
        }
    }
}

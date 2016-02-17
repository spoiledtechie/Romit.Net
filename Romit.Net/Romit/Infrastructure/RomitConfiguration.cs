using System.Configuration;

namespace Romit
{
    public static class RomitConfiguration
    {
        private static string _apiKey;

        static RomitConfiguration()
        {
        }

        internal static string GetApiKey()
        {
            if (string.IsNullOrEmpty(_apiKey))
                _apiKey = ConfigurationManager.AppSettings["RomitApiKey"];

            return _apiKey;
        }

        public static void SetApiKey(string newApiKey)
        {
            _apiKey = newApiKey;
        }

        public static string ApiVersion { get; internal set; }
    }
}

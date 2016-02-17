namespace Romit
{
    internal static class Urls
    {
        private static string BaseUrl
        {
            get { return "https://api.romit.io/v1"; }
        }
        public static string OAuthToken
        {
            get { return BaseUrl + "/oauth/token"; }
        }

        public static string UserAuthorization
        {
            get { return BaseConnectUrlOauth + "/oauth/authorize"; }
        }

        private static string BaseConnectUrlOauth
        {
            get { return "https://wallet.romit.io"; }
        }
    }
}

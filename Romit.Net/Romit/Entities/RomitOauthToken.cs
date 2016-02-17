using Newtonsoft.Json;
using System;

namespace Romit
{
    public class RomitOauthToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("access_token_expires")]
        public DateTime AccessTokenExpires { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("refresh_token_expires")]
        public string RefreshTokenExpires { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}

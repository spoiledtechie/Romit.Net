using Newtonsoft.Json;

namespace Romit
{
    public class RomitRequestUserAuthorization
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("response_type")]
        public string ResponseType { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}

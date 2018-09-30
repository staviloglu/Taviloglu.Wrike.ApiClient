using Newtonsoft.Json;

namespace Taviloglu.Wrike.ApiClient.Dto.Authorization
{
    public class WrikeAccessTokenResponse : WrikeRefreshTokenResponse
    {
        [JsonProperty("host")]
        public string Host { get; set; }
    }
}

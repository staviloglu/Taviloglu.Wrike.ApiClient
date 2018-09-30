using Newtonsoft.Json;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.ApiClient.Dto.Authorization
{
    public class WrikeAuthorizationRequest
    {
        public WrikeAuthorizationRequest(string clientId, string clientSecret, GrantType grantType)
        {
            clientId.ValidateParameter(nameof(clientId));
            clientSecret.ValidateParameter(nameof(clientSecret));

            ClientId = clientId;
            ClientSecret = clientSecret;
            GrantType = grantType;

        }

        [JsonProperty("client_id")]
        public string ClientId { get; private set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; private set; }

        [JsonProperty("grant_type")]
        public GrantType GrantType { get; private set; }
    }
}

using Newtonsoft.Json;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.ApiClient.Dto.Authorization
{
    public class WrikeAccessTokenRequest : WrikeAuthorizationRequest
    {
        public WrikeAccessTokenRequest(string clientId, string clientSecret, string authorizationCode) : base(clientId, clientSecret, GrantType.authorization_code)
        {

            authorizationCode.ValidateParameter(nameof(authorizationCode));

            AuthorizationCode = authorizationCode;
        }

        [JsonProperty("code")]
        public string AuthorizationCode { get; private set; }
    }
}

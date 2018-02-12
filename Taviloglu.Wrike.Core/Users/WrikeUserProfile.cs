using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeUserProfile
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Role in account 
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeUserRole Role { get; set; }

        [JsonProperty("external")]
        public bool External { get; set; }
        [JsonProperty("admin")]
        public bool Admin { get; set; }
        [JsonProperty("owner")]
        public bool Owner { get; set; }
    }

}

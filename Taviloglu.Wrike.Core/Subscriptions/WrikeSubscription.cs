using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core
{
    public class WrikeSubscription : IWrikeObject
    {
        /// <summary>
        /// Subscription type 
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeSubscriptionType Type { get; set; }
        /// <summary>
        /// Subscription is paid (available only to account admins)
        /// </summary>
        [JsonProperty("paid")]
        public bool Paid { get; set; }

        /// <summary>
        /// Limit of subscription users (available only to account admins)
        /// </summary>
        [JsonProperty("userLimit")]
        public int UserLimit { get; set; }
    }
}

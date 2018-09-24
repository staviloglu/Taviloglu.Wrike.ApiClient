using Newtonsoft.Json;
namespace Taviloglu.Wrike.Core.Ids
{
    /// <summary>
    /// APIv2 legacy ID with new ID
    /// </summary>
    public class WrikeApiV2Id : IWrikeObject
    {
        /// <summary>
        /// API v3 ID
        /// </summary>
        [JsonProperty("id")]
        public string NewID { get; set; }

        /// <summary>
        /// API v2 legacy ID
        /// </summary>
        [JsonProperty("apiV2Id")]
        public int Value { get; set; }
    }
}

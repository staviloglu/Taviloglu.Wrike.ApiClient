using Newtonsoft.Json;
namespace Taviloglu.Wrike.Core.Ids
{

    public class WrikeId : WrikeObjectWithId
    {
        /// <summary>
        /// API v2 legacy ID
        /// </summary>
        [JsonProperty("apiV2Id")]
        public string ApiV2Id { get; set; }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomField : WrikeObjectWithId
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldType Type { get; set; }

        [JsonProperty("sharedIds")]
        public List<string> SharedIds { get; set; }
    }
}

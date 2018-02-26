using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomStatus : WrikeObjectWithId
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("standard")]
        public bool Standard { get; set; }
        [JsonProperty("group")]
        public string Group { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeColor.Value Color { get; set; }
    }


}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomStatus : WrikeObjectWithId
    {
        /// <summary>
        /// Name (128 symbols max)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Defines default custom status (ignored in requests)
        /// </summary>
        [JsonProperty("standard")]
        public bool Standard { get; set; }
        /// <summary>
        /// Custom status group Task Status
        /// </summary>
        [JsonProperty("group")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskStatus Group { get; set; }
        /// <summary>
        /// Custom status is hidden
        /// </summary>
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        /// <summary>
        /// Color name 
        /// </summary>
        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeColor.CustomStatusColor Color { get; set; }
    }


}

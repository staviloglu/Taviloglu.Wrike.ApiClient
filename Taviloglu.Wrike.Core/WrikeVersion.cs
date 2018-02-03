using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeVersion
    {
        /// <summary>
        /// Major version number
        /// </summary>
        [JsonProperty(PropertyName = "major")]
        public string Major { get; set; }
        /// <summary>
        /// Minor version number
        /// </summary>
        [JsonProperty(PropertyName = "minor")]
        public string Minor { get; set; }
    }
}

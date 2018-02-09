using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeVersion : IWrikeObject
    {
        /// <summary>
        /// Major version number
        /// </summary>
        [JsonProperty("major")]
        public string Major { get; set; }
        /// <summary>
        /// Minor version number
        /// </summary>
        [JsonProperty("minor")]
        public string Minor { get; set; }
    }
}

using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeKeyValue
    {
        /// <summary>
        /// Key should be less than 50 symbols and match following regular expression ([A-Za-z0-9_-]+)
        /// </summary>
        [JsonProperty(PropertyName="key")]
        public string Key { get; set; }
        /// <summary>
        /// Value should be less than 1000 symbols, compatible with JSON string. Use JSON 'null' in order to remove metadata entry
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}

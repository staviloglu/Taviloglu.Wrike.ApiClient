using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomFieldData : WrikeObject
    {
        /// <summary>
        /// Custom field value
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}

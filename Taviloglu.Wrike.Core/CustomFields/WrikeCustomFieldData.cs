using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeCustomFieldData : WrikeObjectWithId
    {
        public WrikeCustomFieldData() { }
        public WrikeCustomFieldData(string id, string value) {
            Id = id;
            Value = value;
        }
        /// <summary>
        /// Custom field value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

    }
}

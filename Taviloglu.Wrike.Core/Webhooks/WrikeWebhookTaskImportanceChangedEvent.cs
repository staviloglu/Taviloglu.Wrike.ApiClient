using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public class WrikeWebHookTaskImportanceChangedEvent : WrikeWebHookEvent
    {
        [JsonProperty("oldValue")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskImportance OldValue { get; set; }

        [JsonProperty("importance")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskImportance Importance { get; set; }
    }
}

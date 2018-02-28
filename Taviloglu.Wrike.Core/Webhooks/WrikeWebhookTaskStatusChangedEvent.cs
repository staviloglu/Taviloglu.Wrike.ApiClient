using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebHookTaskStatusChangedEvent : WrikeWebHookEvent
    {
        [JsonProperty("oldStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskStatus OldStatus { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskStatus Status { get; set; }
    }
}

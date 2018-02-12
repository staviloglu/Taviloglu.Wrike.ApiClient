using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWebhookTaskStatusChangedEvent : WrikeWebhookEvent
    {
        [JsonProperty("oldStatus")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskStatus OldStatus { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskStatus Status { get; set; }
    }
}

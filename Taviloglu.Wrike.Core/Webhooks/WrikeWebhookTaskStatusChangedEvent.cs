using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebHookTaskStatusChangedEvent : WrikeWebHookEvent
    {
        [JsonProperty("oldStatus")]
        public string OldStatus { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("oldCustomStatusId")]
        public string OldCustomStatusId { get; set; }
        [JsonProperty("customStatusId")]
        public string CustomStatusId { get; set; }
    }
}

using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebhookTaskTitleChangedEvent : WrikeWebhookEvent
    {
        [JsonProperty("oldValue")]
        public string OldValue { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

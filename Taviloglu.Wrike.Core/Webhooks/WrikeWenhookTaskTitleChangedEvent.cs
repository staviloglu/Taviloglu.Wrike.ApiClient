using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWenhookTaskTitleChangedEvent : WrikeWebhookEvent
    {
        [JsonProperty("oldValue")]
        public string OldValue { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public sealed class WrikeWebHookTaskTitleChangedEvent : WrikeWebHookEvent
    {
        [JsonProperty("oldValue")]
        public string OldValue { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}

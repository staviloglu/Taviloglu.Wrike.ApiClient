using Newtonsoft.Json;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public class WrikeWebHookTaskDatesChangedEvent : WrikeWebHookEvent
    {
        /// <summary>
        /// Type and WorkOnWeekends value should be checked
        /// </summary>
        [JsonProperty("oldValue")]
        public WrikeWebHookTaskDate OldValue { get; set; }
        [JsonProperty("dates")]
        public WrikeWebHookTaskDate Dates { get; set; }
    }
}

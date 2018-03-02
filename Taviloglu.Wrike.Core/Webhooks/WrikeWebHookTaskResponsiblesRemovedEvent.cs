using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebHookTaskResponsiblesRemovedEvent : WrikeWebHookEvent
    {
        [JsonProperty("removedResponsibles")]
        public List<string> RemovedResponsibles { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebHookTaskParentsRemovedEvent : WrikeWebHookEvent
    {
        [JsonProperty("removedParents")]
        public List<string> RemovedParents { get; set; }
    }
}

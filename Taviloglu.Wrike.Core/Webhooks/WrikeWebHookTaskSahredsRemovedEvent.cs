using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebHookTaskSahredsRemovedEvent : WrikeWebHookEvent
    {
        [JsonProperty("removedShareds")]
        public List<string> RemovedShareds { get; set; }
    }
}

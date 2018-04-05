using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeWebHookTaskSharedsAddedEvent : WrikeWebHookEvent
    {
        [JsonProperty("addedShareds")]
        public List<string> AddedShareds { get; set; }
    }
}

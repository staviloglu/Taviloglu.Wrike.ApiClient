using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public sealed class WrikeWebHookTaskSharedsAddedEvent : WrikeWebHookEvent
    {
        [JsonProperty("addedShareds")]
        public List<string> AddedShareds { get; set; }
    }
}

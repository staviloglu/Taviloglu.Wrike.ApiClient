using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.Webhooks
{
    public sealed class WrikeWebHookTaskParentsAddedEvent : WrikeWebHookEvent
    {
        [JsonProperty("addedParents")]
        public List<string> AddedParents { get; set; }
    }
}

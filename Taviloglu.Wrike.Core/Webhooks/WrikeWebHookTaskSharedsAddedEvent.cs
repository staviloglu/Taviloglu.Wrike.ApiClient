using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.WebHooks
{
    public sealed class WrikeWebHookTaskSharedsAddedEvent : WrikeWebHookEvent
    {
        [JsonProperty("addedShareds")]
        public List<string> AddedShareds { get; set; }
    }
}

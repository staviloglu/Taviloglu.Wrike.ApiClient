using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWebHookTaskImportanceChangedEvent : WrikeWebHookEvent
    {
        [JsonProperty("oldValue")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskImportance OldValue { get; set; }
        [JsonProperty("importance")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskImportance Importance { get; set; }
    }
}

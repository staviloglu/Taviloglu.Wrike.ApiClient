using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWebhook : WrikeObjectWithId
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }
        [JsonProperty("hookUrl")]
        public string HookUrl { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeWebhookStatus Status { get; set; }
    }
    

}

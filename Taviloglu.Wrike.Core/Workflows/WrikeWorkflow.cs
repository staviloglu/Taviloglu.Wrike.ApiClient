using Newtonsoft.Json;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWorkflow : WrikeObjectWithId
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("standard")]
        public bool Standard { get; set; }
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        [JsonProperty("customStatuses")]
        public List<WrikeCustomStatus> CustomStatuses { get; set; }
    }
}

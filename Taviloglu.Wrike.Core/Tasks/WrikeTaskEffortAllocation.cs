using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.Tasks
{
    public sealed class WrikeTaskEffortAllocation : IWrikeObject
    {
        /// <summary>
        /// Task Effort mode 
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskEffortMode Mode { get; set; }
        /// <summary>
        /// Task total Effort in minutes
        /// </summary>
        [JsonProperty("totalEffort")]
        public int? TotalEffort { get; set; }
        /// <summary>
        /// Task allocated Effort in minutes
        /// </summary>
        [JsonProperty("allocatedEffort")]
        public int? AllocatedEffort { get; set; }
    }

}


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.Tasks
{
    public sealed class WrikeTaskDate : IWrikeObject
    {
        /// <summary>
        /// Type 
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskDateType Type { get; set; }
        /// <summary>
        ///  [0, 1800000)
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }
        /// <summary>
        /// Start date is present only in Planned tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss" })]
        public DateTime Start { get; set; }
        /// <summary>
        /// Due date is present only in Planned and Milestone tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [JsonProperty("due")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss" })]
        public DateTime Due { get; set; }

        /// <summary>
        /// Weekends are included in task scheduling
        /// </summary>
        [JsonProperty("workOnWeekends")]
        public bool WorkOnWeekends { get; set; }
    }

}


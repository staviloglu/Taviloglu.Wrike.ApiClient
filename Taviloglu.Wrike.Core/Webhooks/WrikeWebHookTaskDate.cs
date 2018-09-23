using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core
{
    /// <summary>
    /// WrikeTaskDate object should be used, but wrike sends request with different property names.
    /// start > startDate | due > dueDate
    /// </summary>
    public sealed class WrikeWebHookTaskDate : IWrikeObject
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
        [JsonProperty("startDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss" })]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Due date is present only in Planned and Milestone tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [JsonProperty("dueDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss" })]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Weekends are included in task scheduling
        /// </summary>
        [JsonProperty("workOnWeekends")]
        public bool WorkOnWeekends { get; set; }
    }
}

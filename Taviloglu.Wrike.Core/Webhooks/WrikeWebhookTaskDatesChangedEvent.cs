using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWebHookTaskDatesChangedEvent : WrikeWebHookEvent
    {
        /// <summary>
        /// Type and WorkOnWeekends value should be checked
        /// </summary>
        [JsonProperty("oldValue")]
        public WrikeWebHookTaskDate OldValue { get; set; }
        [JsonProperty("dates")]
        public WrikeWebHookTaskDate Dates { get; set; }
    }
}

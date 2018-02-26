using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWorkflow : WrikeObjectWithId
    {
        public WrikeWorkflow() { }

        /// <summary>
        /// Use this constructor for creating new workflows
        /// </summary>
        /// <param name="name"></param>
        public WrikeWorkflow(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name ));
            }

            Name = name;
        }
        /// <summary>
        /// Name (128 symbols max)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Defines default workflow
        /// </summary>
        [JsonProperty("standard")]
        public bool Standard { get; set; }
        /// <summary>
        /// Workflow is hidden
        /// </summary>
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        /// <summary>
        /// Custom statuses
        /// </summary>
        [JsonProperty("customStatuses")]
        public List<WrikeCustomStatus> CustomStatuses { get; set; }
    }
}

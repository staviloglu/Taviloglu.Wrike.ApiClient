using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeWorkflow : WrikeObjectWithId
    {

        /// <summary>
        /// Use this constructor for creating new workflows
        /// </summary>
        /// <param name="name"></param>
        public WrikeWorkflow(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(name), "id can not be empty");
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

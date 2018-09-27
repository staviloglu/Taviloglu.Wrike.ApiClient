using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.Workflows
{
    public class WrikeWorkflow : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeWorkflow"></see> class with name
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
                throw new ArgumentException("value can not be empty",nameof(name));
            }

            Name = name;
        }
        /// <summary>
        /// Name (128 symbols max)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }
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

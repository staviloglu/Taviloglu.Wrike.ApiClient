using Newtonsoft.Json;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;

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
            name.ValidateParameter(nameof(name));

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

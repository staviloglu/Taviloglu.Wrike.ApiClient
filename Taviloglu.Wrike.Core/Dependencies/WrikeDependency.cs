using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.Dependencies
{
    public class WrikeDependency : WrikeObjectWithId
    {
        public WrikeDependency(string predecessorId, string successorId, WrikeDependencyRelationType relationType)
        {
            successorId.ValidateParameter(nameof(successorId));
            predecessorId.ValidateParameter(nameof(predecessorId));

            PredecessorId = predecessorId;
            SuccessorId = successorId;
            RelationType = relationType;
        }
        /// <summary>
        /// Predecessor task ID
        /// </summary>
        [JsonProperty("predecessorId")]
        public string PredecessorId { get; private set; }

        /// <summary>
        /// SuccessorId task ID
        /// </summary>
        [JsonProperty("successorId")]
        public string SuccessorId { get; private set; }

        /// <summary>
        /// Relation between Predecessor and Successor 
        /// </summary>
        [JsonProperty("relationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeDependencyRelationType RelationType { get; private set; }
    }
}

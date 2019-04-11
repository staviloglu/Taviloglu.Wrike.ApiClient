using Newtonsoft.Json;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.Comments
{
    public class WrikeTaskComment : WrikeComment
    {
        public WrikeTaskComment(string text, string taskId) : base(text)
        {
            taskId.ValidateParameter(nameof(taskId));

            TaskId = taskId;
        }

        [JsonConstructor]
        private WrikeTaskComment(){ }

        /// <summary>
        /// ID of related task.
        /// </summary>
        [JsonProperty("taskId")]
        public string TaskId { get; private set; }
    }
}

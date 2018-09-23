using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taviloglu.Wrike.Core
{
    public class WrikeTaskComment : WrikeComment
    {
        public WrikeTaskComment(string text, string taskId) : base(text)
        {
            if (taskId == null)
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            if (taskId.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(taskId));
            }

            TaskId = taskId;
        }

        /// <summary>
        /// ID of related task.
        /// </summary>
        [JsonProperty("taskId")]
        public string TaskId { get; private set; }
    }
}

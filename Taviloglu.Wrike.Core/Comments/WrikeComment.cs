using Newtonsoft.Json;
using System;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeComment : WrikeObjectWithId
    {
        public WrikeComment()
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="text">Comment text, can not be empty</param>
        /// <param name="taskId">Create comment in task.</param>
        /// <param name="folderId">Create a comment in the folder. The virtual Root and Recycle Bin folders cannot have comments.</param>
        public WrikeComment(string text, string taskId = null, string folderId=null)
        {
            int idCount = 0;
            if (!string.IsNullOrWhiteSpace(taskId))
            {
                idCount++;
                TaskId = taskId;
            }
            if (!string.IsNullOrWhiteSpace(folderId))
            {
                idCount++;
                FolderId = FolderId;
            }
            if (idCount!=1)
            {
                throw new Exception("only taskId or folderId can be used");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
        }
        /// <summary>
        /// Author ID
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }
        /// <summary>
        /// Comment text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// Created date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>        
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// ID of related task. Only one of taskId/folderId fields is present
        /// </summary>
        [JsonProperty("taskId")]
        public string TaskId { get; set; }
        /// <summary>
        /// ID of related folder. Only one of taskId/folderId fields is present
        /// </summary>
        [JsonProperty("folderId")]
        public string FolderId { get; set; }
    }
}

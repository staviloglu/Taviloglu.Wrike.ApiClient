using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taviloglu.Wrike.Core
{

    public sealed class WrikeAttachment : WrikeObjectWithId
    {
        /// <summary>
        /// Author Id
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        [JsonProperty("currentAttachmentId")]
        public string CurrentAttachmentId { get; set; }
    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core
{
    public abstract class WrikeComment : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeComment"/> class.
        /// </summary>
        /// <param name="text">Comment text, can not be empty</param>
        public WrikeComment(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(text));
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
        public string Text { get; private set; }

        /// <summary>
        /// Created date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>        
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Updated date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>        
        [JsonProperty("updatedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// List of attachment IDs
        /// </summary>
        [JsonProperty("attachmentIds")]
        public List<string> AttachmentIds { get; set; }
    }
}

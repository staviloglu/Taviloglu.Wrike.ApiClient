using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.Attachments
{

    public abstract class WrikeAttachment : WrikeObjectWithId
    {
        /// <summary>
        /// ID of user who uploaded the attachment
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Attachment filename
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Upload date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Attachment version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// Attachment type 
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeAttachmentType Type { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Size for Wrike Attachments. For external attachments, size is equal to -1
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// ID of related comment
        /// </summary>
        [JsonProperty("commentId")]
        public string CommentId { get; set; }

        /// <summary>
        /// Link to download attachment
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// ID of current attachment version
        /// </summary>
        [JsonProperty("currentAttachmentId")]
        public string CurrentAttachmentId { get; set; }

        /// <summary>
        /// Link to download external attachment preview (present if preview is available)
        /// </summary>
        [JsonProperty("previewUrl")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Review IDs
        /// </summary>
        [JsonProperty("reviewIds")]
        public List<string> ReviewIds { get; set; }

        /// <summary>
        /// If is image
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// If is image
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }


    }

}

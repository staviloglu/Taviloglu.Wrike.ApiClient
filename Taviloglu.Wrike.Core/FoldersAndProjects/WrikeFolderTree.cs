using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{

    public sealed class WrikeFolderTree : WrikeObjectWithId
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Color 
        /// </summary>
        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeColor.Value Color { get; set; }

        /// <summary>
        /// Child folder IDs
        /// </summary>
        [JsonProperty("childIds")]
        public List<string> ChildIds { get; set; }

        /// <summary>
        /// Folder scope 
        /// </summary>
        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTreeScope Scope { get; set; }

        /// <summary>
        /// Project details, present only for project folders
        /// </summary>
        [JsonProperty("project")]
        public WrikeProject Project { get; set; }

        /// <summary>
        /// Json string array of optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields {
            public const string Metadata = "metadata";
            public const string HasAttachments = "hasAttachments";
            public const string AttachmentCount = "attachmentCount";
            public const string Description = "description";
            public const string BriefDescription = "briefDescription";
            public const string CustomFields = "customFields";
            public const string CustomColumnIds = "customColumnIds";
            public const string SuperParentIds = "superParentIds";
        }
    }


}

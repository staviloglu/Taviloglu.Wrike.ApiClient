using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Colors;

namespace Taviloglu.Wrike.Core.FoldersAndProjects
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
        public WrikeColor.FolderColor Color { get; set; }

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
        /// Optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields
        {
            public static List<string> List = new List<string> { Metadata, HasAttachments, AttachmentCount, Description, BriefDescription, CustomFields, CustomColumnIds, SuperParentIds, Color };
            public const string Metadata = "metadata";
            public const string HasAttachments = "hasAttachments";
            public const string AttachmentCount = "attachmentCount";
            public const string Description = "description";
            public const string BriefDescription = "briefDescription";
            public const string CustomFields = "customFields";
            public const string CustomColumnIds = "customColumnIds";
            public const string SuperParentIds = "superParentIds";
            public const string Color = "color";
        }
    }


}

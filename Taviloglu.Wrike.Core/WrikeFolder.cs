using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeFolder : WrikeObject
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Created date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
       [JsonProperty(PropertyName = "createdDate",
            ItemConverterType = typeof(CustomDateTimeConverter),
            ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Updated date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
       [JsonProperty(PropertyName = "updatedDate",
            ItemConverterType = typeof(CustomDateTimeConverter),
            ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Brief description
        /// </summary>
        [JsonProperty(PropertyName = "briefDescription")]
        public string BriefDescription { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Color 
        /// </summary>
        [JsonProperty(PropertyName = "color", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeColor.Value Color { get; set; }

        /// <summary>
        /// List of user IDs, who share the folder
        /// </summary>
        [JsonProperty(PropertyName = "sharedIds")]
        public List<string> SharedIds { get; set; }

        /// <summary>
        /// List of parent folder IDs
        /// </summary>
        [JsonProperty(PropertyName = "parentIds")]
        public List<string> ParentIds { get; set; }
        /// <summary>
        /// List of child folder IDs
        /// </summary>
        [JsonProperty(PropertyName = "childIds")]
        public List<string> ChildIds { get; set; }

        /// <summary>
        /// List of super parent folder IDs
        /// </summary>
        [JsonProperty(PropertyName = "superParentIds")]
        public List<string> SuperParentIds { get; set; }

        /// <summary>
        /// Folder scope 
        /// </summary>
        [JsonProperty(PropertyName = "scope", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeTreeScope Scope { get; set; }

        /// <summary>
        /// True if folder has attachments
        /// </summary>
        [JsonProperty(PropertyName = "hasAttachments")]
        public bool HasAttachments { get; set; }
        /// <summary>
        /// Total count of folder attachments
        /// </summary>
        [JsonProperty(PropertyName = "attachmentCount")]
        public string AttachmentCount { get; set; }
        /// <summary>
        /// Link to open folder in web workspace, if user has appropriate access
        /// </summary>
        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }
        /// <summary>
        /// Folder workflow ID
        /// </summary>
        [JsonProperty(PropertyName = "workfloId")]
        public string WorkflowId { get; set; }
        /// <summary>
        /// List of folder metadata entries
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public List<WrikeKeyValue> Metadata { get; set; }
        /// <summary>
        /// Custom fields
        /// </summary>
        [JsonProperty(PropertyName = "customFields")]
        public List<WrikeCustomField> CustomFields { get; set; }
        /// <summary>
        /// Custom column IDs
        /// </summary>
        [JsonProperty(PropertyName = "customColumnIds")]
        public List<string> CustomColumnIds { get; set; }

        /// <summary>
        /// Project details, present only for project folders
        /// </summary>
        [JsonProperty(PropertyName = "project")]
        public List<WrikeProject> Project { get; set; }

        /// <summary>
        /// Json string array of optional fields to be included in the response model
        /// </summary>
        public class OptionalFields
        {
            /// <summary>
            /// Get brief description
            /// </summary>
            public const string BriefDescription = "briefDescription";
            /// <summary>
            /// Associated custom field IDs
            /// </summary>
            public const string CustomColumnIds = "customColumnIds"; //todo: check if there is an error - returned null not 0
            /// <summary>
            /// Attachment count
            /// </summary>
            public const string AttachmentCount = "attachmentCount";
        }

    }
}

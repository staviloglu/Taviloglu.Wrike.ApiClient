using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeTask : WrikeObject
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Title, cannot be empty
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }


        /// <summary>
        /// Brief description
        /// </summary>
        [JsonProperty(PropertyName = "briefDescription")]
        public string BriefDescription { get; set; }
        /// <summary>
        /// List of task parent folder IDs
        /// </summary>
        [JsonProperty(PropertyName = "parentIds")]
        public List<string> ParentIds { get; set; }
        /// <summary>
        /// List of task super parent folder IDs
        /// </summary>
        [JsonProperty(PropertyName = "superParentIds")]
        public List<string> SuperParentIds { get; set; }
        /// <summary>
        /// List of user IDs, who share the task
        /// </summary>
        [JsonProperty(PropertyName = "sharedIds")]
        public List<string> SharedIds { get; set; }

        /// <summary>
        /// List of responsible user IDs
        /// </summary>
        [JsonProperty(PropertyName = "responsibleIds")]
        public List<string> ResponsibleIds { get; set; }
        /// <summary>
        /// Status of task 
        /// </summary>
        [JsonProperty(PropertyName = "status", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeTaskStatus Status { get; set; }
        /// <summary>
        /// Importance of task 
        /// </summary>
        [JsonProperty(PropertyName = "importance", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeTaskImportance Importance { get; set; }

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
        /// Completed date, field is present for tasks with 'Completed' status Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty(PropertyName = "completedDate",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CompletedDate { get; set; }
        /// <summary>
        /// Task dates
        /// </summary>
        [JsonProperty(PropertyName = "dates")]
        public WrikeTaskDate Dates { get; set; }
        [JsonProperty(PropertyName = "scope", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeTreeScope Scope { get; set; }
        /// <summary>
        /// List of author IDs (currently contains 1 element)
        /// </summary>
        [JsonProperty(PropertyName = "authorIds")]
        public List<string> AuthorIds { get; set; }
        [JsonProperty(PropertyName = "customStatusId")]
        public string CustomStatusId { get; set; }
        [JsonProperty(PropertyName = "hasAttachments")]
        public bool HasAttachments { get; set; }
        [JsonProperty(PropertyName = "attachmentCount")]
        public int AttachmentCount { get; set; }
        /// <summary>
        /// Link to open task in web workspace, if user has appropriate access
        /// </summary>
        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }
        /// <summary>
        /// Ordering key that defines task order in tasklist
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }
        [JsonProperty(PropertyName = "followedByMe")]
        public bool FollowedByMe { get; set; }
        [JsonProperty(PropertyName = "followerIds")]
        public List<string> FollowerIds { get; set; }

        /// <summary>
        /// Is a task recurrent
        /// </summary>
        [JsonProperty(PropertyName = "recurrent")]
        public bool Recurrent { get; set; }

        [JsonProperty(PropertyName = "superTaskIds")]
        public List<string> SuperTaskIds { get; set; }
        [JsonProperty(PropertyName = "subTaskIds")]
        public List<string> SubTaskIds { get; set; }
        [JsonProperty(PropertyName = "dependencyIds")]
        public List<string> DependencyIds { get; set; }
        [JsonProperty(PropertyName = "metadata")]
        public List<WrikeMetadata> Metadata { get; set; }
        [JsonProperty(PropertyName = "customFields")]
        public List<WrikeCustomFieldData> CustomFields { get; set; }

        /// <summary>
        /// Json string array of optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields
        {
            /// <summary>
            /// Author IDs
            /// </summary>
            public const string AuthorIds = "authorIds";
            /// <summary>
            /// Has attachments
            /// </summary>
            public const string HasAttachments = "hasAttachments";
            /// <summary>
            /// Attachment count
            /// </summary>
            public const string AttachmentCount = "attachmentCount";
            /// <summary>
            /// List of task parent folder
            /// </summary>
            public const string ParentIds = "parentIds";
            /// <summary>
            /// List of task super parent folder
            /// </summary>
            public const string SuperParentIds = "superParentIds";
            /// <summary>
            /// List of user IDs, who have task share
            /// </summary>
            public const string SharedIds = "sharedIds";
            /// <summary>
            /// List of responsible user IDs
            /// </summary>
            public const string ResponsibleIds = "responsibleIds";
            /// <summary>
            /// Description
            /// </summary>
            public const string Description = "description";
            /// <summary>
            /// Brief description
            /// </summary>
            public const string BriefDescription = "briefDescription";
            /// <summary>
            /// Is a task recurrent
            /// </summary>
            public const string Recurrent = "recurrent";
            /// <summary>
            /// List of supertask IDs
            /// </summary>
            public const string SuperTaskIds = "superTaskIds";
            /// <summary>
            /// List of subtask IDs
            /// </summary>
            public const string subTaskIds = "subTaskIds";
            /// <summary>
            /// Dependency IDs
            /// </summary>
            public const string dependencyIds = "dependencyIds";
            /// <summary>
            /// Task metadata entries
            /// </summary>
            public const string metadata = "metadata";
            /// <summary>
            /// Custom fields
            /// </summary>
            public const string CustomFields = "customFields";
        }
    }

}


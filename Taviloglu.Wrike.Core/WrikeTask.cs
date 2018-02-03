using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        [JsonProperty(PropertyName = "importance", ItemConverterType =typeof(StringEnumConverter))]
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
        public Dates Dates { get; set; }
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
        [JsonProperty(PropertyName = "authorIds")]
        public List<string> AuthorIds { get; set; }
        [JsonProperty(PropertyName = "customStatusId")]
        public string CustomStatusId { get; set; }
        [JsonProperty(PropertyName = "hasAttachments")]
        public bool HasAttachments { get; set; }
        [JsonProperty(PropertyName = "attachmentCount")]
        public int AttachmentCount { get; set; }
        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }
        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }
        [JsonProperty(PropertyName = "followedByMe")]
        public bool FollowedByMe { get; set; }
        [JsonProperty(PropertyName = "followerIds")]
        public List<string> FollowerIds { get; set; }
        [JsonProperty(PropertyName = "superTaskIds")]
        public List<string> SuperTaskIds { get; set; }
        [JsonProperty(PropertyName = "subTaskIds")]
        public List<string> SubTaskIds { get; set; }
        [JsonProperty(PropertyName = "dependencyIds")]
        public List<string> DependencyIds { get; set; }
        [JsonProperty(PropertyName = "metadata")]
        public List<WrikeMetadata> Metadata { get; set; }
        [JsonProperty(PropertyName = "customFields")]
        public List<WrikeCustomField> CustomFields { get; set; }
    }

    public class Dates
    {
        /// <summary>
        /// Type 
        /// </summary>
        [JsonProperty(PropertyName = "type", ItemConverterType =typeof(StringEnumConverter))]
        public WrikeTaskDateType Type { get; set; }
        /// <summary>
        ///  [0, 1800000)
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }
        /// <summary>
        /// Start date is present only in Planned tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [JsonProperty(PropertyName = "start",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss" })]
        public DateTime Start { get; set; }
        /// <summary>
        /// Due date is present only in Planned and Milestone tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [JsonProperty(PropertyName = "due",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss" })]
        public DateTime Due { get; set; }
    }

}

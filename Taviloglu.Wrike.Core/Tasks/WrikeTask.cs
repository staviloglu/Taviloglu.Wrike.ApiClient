using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.Extensions;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.Tasks
{
    /// <summary>
    /// Task
    /// </summary>
    public sealed class WrikeTask : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeTask"></see> class with title
        /// </summary>
        /// <param name="title">Title of task, required</param>
        /// <param name="description">Description of task, will be left blank, if not set</param>
        /// <param name="status">Status of task </param>
        /// <param name="importance">Importance of task </param>
        /// <param name="dates">Task dates. If not specified, a backlogged task is created</param>
        /// <param name="shareds">Shares task with specified users. The task is always shared with the author.</param>
        /// <param name="parents">Parent folders for newly created task. Can not contain recycleBinId</param>
        /// <param name="responsibles">Makes specified users responsible for the task</param>
        /// <param name="followers">Add specified users to task followers</param>
        /// <param name="follow">Follow task</param>   
        /// <param name="superTasks">Add the task as subtask to specified tasks</param>
        /// <param name="metadata">Metadata to be added to newly created task</param>
        /// <param name="customFields">List of custom fields to set in newly created task</param>
        /// <param name="customStatus">Custom status ID</param>
        /// <param name="effortAllocation">Task Effort allocation</param>
        public WrikeTask(
            string title,
            string description = null,
            WrikeTaskStatus status = WrikeTaskStatus.Active,
            WrikeTaskImportance importance = WrikeTaskImportance.Normal,
            WrikeTaskDate dates = null,
            List<string> shareds = null,
            List<string> parents = null,
            List<string> responsibles = null,
            List<string> followers = null,
            bool follow = false,
            List<string> superTasks = null,
            List<WrikeMetadata> metadata = null,
            List<WrikeCustomFieldData> customFields = null,
            string customStatus = null,
            WrikeTaskEffortAllocation effortAllocation = null,
            string customItemTypeId = null)
        {
            title.ValidateParameter(nameof(title));

            Title = title;
            Description = description;
            Status = status;
            Importance = importance;
            Dates = dates;
            SharedIds = shareds;
            ParentIds = parents;
            ResponsibleIds = responsibles;
            FollowerIds = followers;
            FollowedByMe = follow;
            SuperTaskIds = superTasks;
            Metadata = metadata;
            CustomFields = customFields;
            CustomStatusId = customStatus;
            EffortAllocation = effortAllocation;
            CustomItemTypeId = customItemTypeId;
        }

        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Title, cannot be empty
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// Brief description
        /// </summary>
        [JsonProperty("briefDescription")]
        public string BriefDescription { get; set; }

        /// <summary>
        /// List of task parent folder IDs
        /// </summary>
        [JsonProperty("parentIds")]
        public List<string> ParentIds { get; set; }

        /// <summary>
        /// List of task super parent folder IDs
        /// </summary>
        [JsonProperty("superParentIds")]
        public List<string> SuperParentIds { get; set; }

        /// <summary>
        /// List of user IDs, who share the task
        /// </summary>
        [JsonProperty("sharedIds")]
        public List<string> SharedIds { get; set; }

        /// <summary>
        /// List of responsible user IDs
        /// </summary>
        [JsonProperty("responsibleIds")]
        public List<string> ResponsibleIds { get; set; }
        /// <summary>
        /// Status of task 
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskStatus Status { get; set; }

        /// <summary>
        /// Importance of task 
        /// </summary>
        [JsonProperty("importance")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTaskImportance Importance { get; set; }

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
        /// Completed date, field is present for tasks with 'Completed' status Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("completedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CompletedDate { get; set; }

        /// <summary>
        /// Task dates
        /// </summary>
        [JsonProperty("dates")]
        public WrikeTaskDate Dates { get; set; }

        /// <summary>
        /// Task scope 
        /// </summary>
        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeTreeScope Scope { get; set; }
        /// <summary>
        /// List of author IDs (currently contains 1 element)
        /// </summary>
        [JsonProperty("authorIds")]
        public List<string> AuthorIds { get; set; }

        /// <summary>
        /// Custom status ID
        /// </summary>
        [JsonProperty("customStatusId")]
        public string CustomStatusId { get; set; }

        /// <summary>
        /// Has attachments
        /// </summary>
        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; }

        /// <summary>
        /// Total count of task attachments
        /// </summary>
        [JsonProperty("attachmentCount")]
        public int AttachmentCount { get; set; }

        /// <summary>
        /// Link to open task in web workspace, if user has appropriate access
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// Ordering key that defines task order in tasklist
        /// </summary>
        [JsonProperty("priority")]
        public string Priority { get; set; }

        /// <summary>
        /// Is a task followed by me
        /// </summary>
        [JsonProperty("followedByMe")]
        public bool FollowedByMe { get; set; }

        /// <summary>
        /// List of user IDs, who follows task
        /// </summary>
        [JsonProperty("followerIds")]
        public List<string> FollowerIds { get; set; }

        /// <summary>
        /// Is a task recurrent
        /// </summary>
        [JsonProperty("recurrent")]
        public bool Recurrent { get; set; }

        /// <summary>
        /// List of super task IDs
        /// </summary>
        [JsonProperty("superTaskIds")]
        public List<string> SuperTaskIds { get; set; }

        /// <summary>
        /// List of subtask IDs
        /// </summary>
        [JsonProperty("subTaskIds")]
        public List<string> SubTaskIds { get; set; }

        /// <summary>
        /// List of dependency IDs
        /// </summary>
        [JsonProperty("dependencyIds")]
        public List<string> DependencyIds { get; set; }

        /// <summary>
        /// List of task metadata entries
        /// </summary>
        [JsonProperty("metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

        /// <summary>
        /// Custom fields
        /// </summary>
        [JsonProperty("customFields")]
        public List<WrikeCustomFieldData> CustomFields { get; set; }

        /// <summary>
        /// Task Effort allocation
        /// </summary>
        [JsonProperty("effortAllocation")]
        public WrikeTaskEffortAllocation EffortAllocation { get; set; }

        /// <summary>
        /// Custom Item Type ID
        /// </summary>
        [JsonProperty("customItemTypeId")]
        public string CustomItemTypeId { get; set; }

        /// <summary>
        /// Optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields
        {
            public static List<string> List = new List<string> { AuthorIds, HasAttachments, AttachmentCount, ParentIds, SuperParentIds, SharedIds, ResponsibleIds, Description, BriefDescription, Recurrent, SuperTaskIds, SubTaskIds, DependencyIds, Metadata };
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
            public const string SubTaskIds = "subTaskIds";
            /// <summary>
            /// Dependency IDs
            /// </summary>
            public const string DependencyIds = "dependencyIds";
            /// <summary>
            /// Task metadata entries
            /// </summary>
            public const string Metadata = "metadata";
            /// <summary>
            /// Custom fields
            /// </summary>
            public const string CustomFields = "customFields";
            /// <summary>
            /// Effort allocation
            /// </summary>
            public const string EffortAllocation = "effortAllocation";
            /// <summary>
            /// Custom Item Type ID
            /// </summary>
            public const string CustomItemTypeId = "customItemTypeId";
        }
    }
}


using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeTask : WrikeObject
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Title, cannot be empty
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }


        /// <summary>
        /// Brief description
        /// </summary>
        [DataMember(Name = "briefDescription")]
        public string BriefDescription { get; set; }
        /// <summary>
        /// List of task parent folder IDs
        /// </summary>
        [DataMember(Name = "parentIds")]
        public List<string> ParentIds { get; set; }
        /// <summary>
        /// List of task super parent folder IDs
        /// </summary>
        [DataMember(Name = "superParentIds")]
        public List<string> SuperParentIds { get; set; }
        /// <summary>
        /// List of user IDs, who share the task
        /// </summary>
        [DataMember(Name = "sharedIds")]
        public List<string> SharedIds { get; set; }

        /// <summary>
        /// List of responsible user IDs
        /// </summary>
        [DataMember(Name = "responsibleIds")]
        public List<string> ResponsibleIds { get; set; }
        /// <summary>
        /// Status of task 
        /// </summary>
        [DataMember(Name = "status")]
        public WrikeTaskStatus Status { get; set; }
        /// <summary>
        /// Importance of task 
        /// </summary>
        [DataMember(Name = "importance")]
        public WrikeTaskImportance Importance { get; set; }

        /// <summary>
        /// Created date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [DataMember(Name = "createdDate")]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Updated date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [DataMember(Name = "updatedDate")]
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Completed date, field is present for tasks with 'Completed' status Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [DataMember(Name="completedDate")]
        public DateTime CompletedDate { get; set; }
        /// <summary>
        /// Task dates
        /// </summary>
        [DataMember(Name = "dates")]
        public Dates Dates { get; set; }
        [DataMember(Name = "scope")]
        public string Scope { get; set; }
        [DataMember(Name = "authorIds")]
        public List<string> AuthorIds { get; set; }
        [DataMember(Name = "customStatusId")]
        public string CustomStatusId { get; set; }
        [DataMember(Name = "hasAttachments")]
        public bool HasAttachments { get; set; }
        [DataMember(Name = "attachmentCount")]
        public int AttachmentCount { get; set; }
        [DataMember(Name = "permalink")]
        public string Permalink { get; set; }
        [DataMember(Name = "priority")]
        public string Priority { get; set; }
        [DataMember(Name = "followedByMe")]
        public bool FollowedByMe { get; set; }
        [DataMember(Name = "followerIds")]
        public List<string> FollowerIds { get; set; }
        [DataMember(Name = "superTaskIds")]
        public List<string> SuperTaskIds { get; set; }
        [DataMember(Name = "subTaskIds")]
        public List<string> SubTaskIds { get; set; }
        [DataMember(Name = "dependencyIds")]
        public List<string> DependencyIds { get; set; }
        [DataMember(Name = "metadata")]
        public List<WrikeMetadata> Metadata { get; set; }
        [DataMember(Name = "customFields")]
        public List<WrikeCustomField> CustomFields { get; set; }
    }

    public class Dates
    {
        /// <summary>
        /// Type 
        /// </summary>
        [DataMember(Name = "type")]
        public WrikeTaskDateType Type { get; set; }
        /// <summary>
        ///  [0, 1800000)
        /// </summary>
        [DataMember(Name = "duration")]
        public int Duration { get; set; }
        /// <summary>
        /// Start date is present only in Planned tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [DataMember(Name = "start")]
        public DateTime Start { get; set; }
        /// <summary>
        /// Due date is present only in Planned and Milestone tasks Format: yyyy-MM-dd'T'HH:mm:ss('T'HH:mm:ss is optional)
        /// </summary>
        [DataMember(Name = "due")]
        public DateTime Due { get; set; }
    }

}

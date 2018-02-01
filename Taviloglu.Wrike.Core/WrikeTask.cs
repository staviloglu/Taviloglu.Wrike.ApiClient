using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeTask : WrikeObject
    {

        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "briefDescription")]
        public string BriefDescription { get; set; }
        [DataMember(Name = "parentIds")]
        public List<string> ParentIds { get; set; }
        [DataMember(Name = "superParentIds")]
        public List<string> SuperParentIds { get; set; }
        [DataMember(Name = "sharedIds")]
        public List<string> SharedIds { get; set; }
        [DataMember(Name = "responsibleIds")]
        public List<string> ResponsibleIds { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "importance")]
        public string Importance { get; set; }
        [DataMember(Name = "createdDate")]
        public DateTime CreatedDate { get; set; }
        [DataMember(Name = "updatedDate")]
        public DateTime UpdatedDate { get; set; }
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
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "duration")]
        public int Duration { get; set; }
        [DataMember(Name = "start")]
        public DateTime Start { get; set; }
        [DataMember(Name = "due")]
        public DateTime Due { get; set; }
    }

}

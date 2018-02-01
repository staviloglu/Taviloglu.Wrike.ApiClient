using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeFolder : WrikeObject
    {

        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "createdDate")]
        public DateTime CreatedDate { get; set; }
        [DataMember(Name = "updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "sharedIds")]
        public List<string> SharedIds { get; set; }
        [DataMember(Name = "parentIds")]
        public List<string> ParentIds { get; set; }
        [DataMember(Name = "superParentIds")]
        public List<string> SuperParentIds { get; set; }
        [DataMember(Name = "childIds")]
        public List<string> ChildIds { get; set; }
        [DataMember(Name = "scope")]
        public string Scope { get; set; }
        [DataMember(Name = "hasAttachments")]
        public bool HasAttachments { get; set; }
        [DataMember(Name = "permalink")]
        public string Permalink { get; set; }
        [DataMember(Name = "workfloId")]
        public string WorkflowId { get; set; }

        [DataMember(Name = "metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

        [DataMember(Name = "customFields")]
        public List<WrikeCustomField> CustomFields { get; set; }

    }
}

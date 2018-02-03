using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeFolder : WrikeObject
    {

       [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }
       [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

       [JsonProperty(PropertyName = "createdDate")]
        public DateTime CreatedDate { get; set; }
       [JsonProperty(PropertyName = "updatedDate")]
        public DateTime UpdatedDate { get; set; }

       [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
       [JsonProperty(PropertyName = "sharedIds")]
        public List<string> SharedIds { get; set; }
       [JsonProperty(PropertyName = "parentIds")]
        public List<string> ParentIds { get; set; }
       [JsonProperty(PropertyName = "superParentIds")]
        public List<string> SuperParentIds { get; set; }
       [JsonProperty(PropertyName = "childIds")]
        public List<string> ChildIds { get; set; }
       [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
       [JsonProperty(PropertyName = "hasAttachments")]
        public bool HasAttachments { get; set; }
       [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }
       [JsonProperty(PropertyName = "workfloId")]
        public string WorkflowId { get; set; }

       [JsonProperty(PropertyName = "metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

       [JsonProperty(PropertyName = "customFields")]
        public List<WrikeCustomField> CustomFields { get; set; }

    }
}

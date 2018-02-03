using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomField : WrikeObject
    {
        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "type")]
        public WrikeCustomFieldType Type { get; set; }

        [DataMember(Name = "sharedIds")]
        public List<string> SharedIds { get; set; }        
    }
}

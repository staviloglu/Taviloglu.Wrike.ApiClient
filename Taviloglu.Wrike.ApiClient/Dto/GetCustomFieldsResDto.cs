using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Dto
{
    public class GetCustomFieldsResDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "sharedIds")]
        public List<string> SharedIds { get; set; }
    }
}

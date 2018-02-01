using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.ApiClient
{
    public class WrikeResponse<T>
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "data")]
        public List<T> Data { get; set; }
    }
}

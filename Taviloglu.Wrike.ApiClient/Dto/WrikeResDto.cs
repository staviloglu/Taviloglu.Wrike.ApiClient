using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.ApiClient.Dto
{
    public class WrikeResDto<T>
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "data")]
        public List<T> Data { get; set; }
        [DataMember(Name = "errorDescription")]
        public string ErrorDescription { get; set; }
        [DataMember(Name = "error")]
        public string Error { get; set; }
        [IgnoreDataMember()]
        public bool IsSuccess { get; set; }
    }
}

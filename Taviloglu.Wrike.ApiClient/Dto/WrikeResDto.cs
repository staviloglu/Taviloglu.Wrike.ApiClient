using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.ApiClient.Dto
{
    internal class WrikeResDto<T>
    {
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }
        [JsonProperty(PropertyName = "nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty(PropertyName = "responseSize")]
        public int ResponseSize { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }
        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
        [IgnoreDataMember()]
        public bool IsSuccess { get; set; }
    }
}

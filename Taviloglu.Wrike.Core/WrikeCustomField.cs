using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomField : WrikeObject
    {
       [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }

       [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

       [JsonProperty(PropertyName = "type", ItemConverterType =typeof(StringEnumConverter))]
        public WrikeCustomFieldType Type { get; set; }

       [JsonProperty(PropertyName = "sharedIds")]
        public List<string> SharedIds { get; set; }        
    }
}

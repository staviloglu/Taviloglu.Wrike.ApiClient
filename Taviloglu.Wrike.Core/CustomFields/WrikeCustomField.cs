using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Extensions;

namespace Taviloglu.Wrike.Core.CustomFields
{
    public sealed class WrikeCustomField : WrikeObjectWithId
    {
        public WrikeCustomField(string title, WrikeCustomFieldType type, List<string> sharedIds = null, WrikeCustomFieldSettings settings = null)
        {
            title.ValidateParameter(nameof(title));

            Title = title;
            Type = type;
            SharedIds = sharedIds;
            Settings = settings;
        }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldType Type { get; private set; }

        [JsonProperty("sharedIds")] 
        public List<string> SharedIds { get; set; }

        [JsonProperty("settings")]        
        public WrikeCustomFieldSettings Settings { get; set; }
    }
}

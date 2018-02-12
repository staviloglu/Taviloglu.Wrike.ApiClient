using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public class WrikeCustomField : WrikeObjectWithId
    {

        public WrikeCustomField() { }

        /// <summary>
        /// Use this constructor for creating new custom field requests
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="sharedIds"></param>
        public WrikeCustomField(string title, WrikeCustomFieldType type, List<string> sharedIds = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("title can not be null or empty!", "title");
            }

            Title = title;
            Type = type;
            SharedIds = sharedIds;
        }


        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeCustomFieldType Type { get; set; }

        [JsonProperty("sharedIds")]
        public List<string> SharedIds { get; set; }
    }
}

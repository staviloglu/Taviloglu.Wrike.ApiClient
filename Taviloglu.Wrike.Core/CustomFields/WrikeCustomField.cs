using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeCustomField : WrikeObjectWithId
    {

        public WrikeCustomField() { }

        /// <summary>
        /// Use this constructor for creating new custom field requests
        /// </summary>
        /// <param name="accountId">AccountId</param>
        /// <param name="title">Title</param>
        /// <param name="type">Type</param>
        /// <param name="sharedIds">Shared people</param>
        public WrikeCustomField(string accountId, string title, WrikeCustomFieldType type, List<string> sharedIds = null)
        {

            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentException("accountId can not be null or empty!", "accountId");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("title can not be null or empty!", "title");
            }

            Title = title;
            Type = type;
            SharedIds = sharedIds;
            AccountId = accountId;
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

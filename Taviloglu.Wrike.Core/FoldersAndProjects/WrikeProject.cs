using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.FoldersAndProjects
{
    public sealed class WrikeProject : IWrikeObject
    {
        /// <summary>
        /// ID of user who created project
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// List of project owner IDs
        /// </summary>
        [JsonProperty("ownerIds")]
        public List<string> OwnerIds { get; set; }

        /// <summary>
        /// Project status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter ( typeof(StringEnumConverter))]
        public WrikeProjectStatus? Status { get; set; }
        /// <summary>
        /// Project start date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("startDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Project end date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("endDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd" })]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Project created date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Project completed date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("completedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime? CompletedDate { get; set; }
		
        /// <summary>
        /// Custom status ID. Empty if status is not Custom
        /// </summary>
        [JsonProperty("customStatusId")]
        public string CustomStatusId { get; set; }		
    }
}

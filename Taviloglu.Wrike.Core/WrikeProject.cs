using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core
{
    public class WrikeProject
    {
        /// <summary>
        /// ID of user who created project
        /// </summary>
        [JsonProperty(PropertyName = "authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// List of project owner IDs
        /// </summary>
        [JsonProperty(PropertyName = "ownerIds")]
        public List<string> OwnerIds { get; set; }

        /// <summary>
        /// Project status
        /// </summary>
        [JsonProperty(PropertyName = "status", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeProjectStatus Status { get; set; }
        /// <summary>
        /// Project start date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty(PropertyName = "startDate",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Project end date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty(PropertyName = "endDate",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Project created date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty(PropertyName = "createdDate",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Project completed date Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty(PropertyName = "completedDate",
             ItemConverterType = typeof(CustomDateTimeConverter),
             ItemConverterParameters = new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime CompletedDate { get; set; }
    }
}

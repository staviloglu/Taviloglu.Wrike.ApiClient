using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{
    public sealed class WrikeGroup : WrikeObjectWithId
    {
        public WrikeGroup(string title, List<string> memberIds = null, List<WrikeMetadata> metadata = null)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (title.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(title), "title can not be empty");
            }

            Title = title;
            MemberIds = memberIds;
            Metadata = metadata;
        }

        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Group title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// List of group members user IDs
        /// </summary>
        [JsonProperty("memberIds")]
        public List<string> MemberIds { get; set; }

        /// <summary>
        /// List of child group IDs
        /// </summary>
        [JsonProperty("childIds")]
        public List<string> ChildIds { get; set; }

        /// <summary>
        /// List of parent group IDs
        /// </summary>
        [JsonProperty("parentIds")]
        public List<string> ParentIds { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Field is present and set to true for My Team (default) group
        /// </summary>
        [JsonProperty("myTeam")]
        public bool MyTeam { get; set; }

        /// <summary>
        /// List of group metadata entries
        /// </summary>
        [JsonProperty("metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

        /// <summary>
        /// Optional fields to be included in the response model 
        /// </summary>
        public class OptionalFields {

            /// <summary>
            /// Group metadata
            /// </summary>
            public const string Metadata = "metadata";
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core.Groups
{
    /// <summary>
    /// User Groups are customizable groups made up of selected users.
    /// </summary>
    public sealed class WrikeGroup : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeGroup"></see> class with the
        ///  title, memberIds and metadata for the new group.
        /// </summary>
        /// <param name="title">Title of group</param>
        /// <param name="memberIds">Group users</param>
        /// <param name="metadata">Metadata to be added to newly created group</param>
        public WrikeGroup(string title, List<string> memberIds = null, List<WrikeMetadata> metadata = null)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (title.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be emtpy", nameof(title));
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
        public class OptionalFields
        {

            public static List<string> List = new List<string> { Metadata };

            /// <summary>
            /// Group metadata
            /// </summary>
            public const string Metadata = "metadata";
        }

    }
}

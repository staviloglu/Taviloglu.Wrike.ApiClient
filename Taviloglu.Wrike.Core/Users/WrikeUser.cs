using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{

    public class WrikeUser : WrikeObjectWithId
    {
        /// <summary>
        /// First name
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        /// <summary>
        /// Type of the user 
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeUserType Type { get; set; }

        /// <summary>
        /// List of user profiles in accounts accessible for requesting user
        /// </summary>
        [JsonProperty("profiles")]
        public List<Profile> Profiles { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Timezone Id, e.g 'America/New_York'
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Locale
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// True if user is deleted, false otherwise
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Field is present and set to true only for requesting user
        /// </summary>
        [JsonProperty("me")]
        public bool Me { get; set; }

        /// <summary>
        /// List of group members contact IDs (field is present only for groups)
        /// </summary>
        [JsonProperty("memberIds")]
        public List<string> MemberIds { get; set; }

        /// <summary>
        /// List of contact metadata entries. Requesting user has read/write access to his own metadata, other entries are read-only
        /// </summary>
        [JsonProperty("metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

        /// <summary>
        /// Field is present and set to true for My Team (default) group
        /// </summary>
        [JsonProperty("myTeam")]
        public bool MyTeam { get; set; }

        /// <summary>
        /// User Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// User Company Name
        /// </summary>
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// User phone
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// User location
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }


    }

    public class Profile
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Role in account 
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeUserRole Role { get; set; }

        [JsonProperty("external")]
        public bool External { get; set; }
        [JsonProperty("admin")]
        public bool Admin { get; set; }
        [JsonProperty("owner")]
        public bool Owner { get; set; }
    }

}

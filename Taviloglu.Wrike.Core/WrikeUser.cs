using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Taviloglu.Wrike.Core
{

    public class WrikeUser : WrikeObject
    {
        /// <summary>
        /// First name
        /// </summary>
       [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
       [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        /// <summary>
        /// Type of the user 
        /// </summary>
       [JsonProperty(PropertyName = "type", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeUserType Type { get; set; }

        /// <summary>
        /// List of user profiles in accounts accessible for requesting user
        /// </summary>
       [JsonProperty(PropertyName = "profiles")]
        public List<Profile> Profiles { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
       [JsonProperty(PropertyName = "avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Timezone Id, e.g 'America/New_York'
        /// </summary>
       [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Locale
        /// </summary>
       [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// True if user is deleted, false otherwise
        /// </summary>
       [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Field is present and set to true only for requesting user
        /// </summary>
       [JsonProperty(PropertyName = "me")]
        public bool Me { get; set; }

        /// <summary>
        /// List of group members contact IDs (field is present only for groups)
        /// </summary>
       [JsonProperty(PropertyName="memberIds")]
        public List<string> MemberIds { get; set; }

        /// <summary>
        /// List of contact metadata entries. Requesting user has read/write access to his own metadata, other entries are read-only
        /// </summary>
       [JsonProperty(PropertyName = "metadata")]
        public List<WrikeMetadata> Metadata { get; set; }

        /// <summary>
        /// Field is present and set to true for My Team (default) group
        /// </summary>
       [JsonProperty(PropertyName = "myTeam")]
        public bool MyTeam { get; set; }

        /// <summary>
        /// User Title
        /// </summary>
       [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// User Company Name
        /// </summary>
       [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// User phone
        /// </summary>
       [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// User location
        /// </summary>
       [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }


    }

    public class Profile
    {
        /// <summary>
        /// Account ID
        /// </summary>
       [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }
       [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Role in account 
        /// </summary>
       [JsonProperty(PropertyName = "role", ItemConverterType = typeof(StringEnumConverter))]
        public WrikeUserRole Role { get; set; }

       [JsonProperty(PropertyName = "external")]
        public bool External { get; set; }
       [JsonProperty(PropertyName = "admin")]
        public bool Admin { get; set; }
       [JsonProperty(PropertyName = "owner")]
        public bool Owner { get; set; }
    }

}

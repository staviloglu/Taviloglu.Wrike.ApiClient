using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{

    public class WrikeUser : WrikeObject
    {
        /// <summary>
        /// First name
        /// </summary>
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        /// <summary>
        /// Type of the user 
        /// </summary>
        [DataMember(Name = "type")]
        public WrikeUserType Type { get; set; }

        /// <summary>
        /// List of user profiles in accounts accessible for requesting user
        /// </summary>
        [DataMember(Name = "profiles")]
        public List<Profile> Profiles { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
        [DataMember(Name = "avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Timezone Id, e.g 'America/New_York'
        /// </summary>
        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Locale
        /// </summary>
        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// True if user is deleted, false otherwise
        /// </summary>
        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Field is present and set to true only for requesting user
        /// </summary>
        [DataMember(Name = "me")]
        public bool Me { get; set; }

        /// <summary>
        /// List of group members contact IDs (field is present only for groups)
        /// </summary>
        [DataMember(Name="memberIds")]
        public List<string> MemberIds { get; set; }

        /// <summary>
        /// List of contact metadata entries. Requesting user has read/write access to his own metadata, other entries are read-only
        /// </summary>
        [DataMember(Name = "metadata")]
        public List<WrikeKeyValue> Metadata { get; set; }

        /// <summary>
        /// Field is present and set to true for My Team (default) group
        /// </summary>
        [DataMember(Name = "myTeam")]
        public bool MyTeam { get; set; }

        /// <summary>
        /// User Title
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// User Company Name
        /// </summary>
        [DataMember(Name = "companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// User phone
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// User location
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; set; }


    }

    public class Profile
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Role in account 
        /// </summary>
        [DataMember(Name = "role")]
        public WrikeUserRole Role { get; set; }

        [DataMember(Name = "external")]
        public bool External { get; set; }
        [DataMember(Name = "admin")]
        public bool Admin { get; set; }
        [DataMember(Name = "owner")]
        public bool Owner { get; set; }
    }

}

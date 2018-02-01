using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taviloglu.Wrike.Core
{

    public class WrikeUser : WrikeObject
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "profiles")]
        public List<Profile> Profiles { get; set; }
        [DataMember(Name = "avatarUrl")]
        public string AvatarUrl { get; set; }
        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }
        [DataMember(Name = "locale")]
        public string Locale { get; set; }
        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }
        [DataMember(Name = "me")]
        public bool Me { get; set; }
    }

    public class Profile
    {
        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "role")]
        public string Role { get; set; }
        [DataMember(Name = "external")]
        public bool External { get; set; }
        [DataMember(Name = "admin")]
        public bool Admin { get; set; }
        [DataMember(Name = "owner")]
        public bool Owner { get; set; }
    }

}

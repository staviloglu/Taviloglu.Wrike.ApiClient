using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.Core.Invitations
{
    /// <summary>
    /// Invitation
    /// </summary>
    public class WrikeInvitation : WrikeObjectWithId
    {

        public WrikeInvitation() {}

        public WrikeInvitation(string accountId, string email, 
            string firstName = null, 
            string lastName = null, 
            WrikeUserRole role = WrikeUserRole.User, bool external = false)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException(nameof(accountId), "accountId can not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email), "email can not be null or empty");
            }
            AccountId = accountId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            External = external;
        }
        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Status 
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeInvitationStatus Status { get; set; }
        /// <summary>
        /// Inviter Contact ID
        /// </summary>
        [JsonProperty("inviterUserId")]
        public string InviterUserId { get; set; }
        /// <summary>
        /// Date when invitation was created Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("invitationDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime InvitationDate { get; set; }

        /// <summary>
        /// Date when the invitation was resolved Format: yyyy-MM-dd'T'HH:mm:ss'Z'
        /// </summary>
        [JsonProperty("resolvedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "yyyy-MM-dd'T'HH:mm:ss'Z'" })]
        public DateTime ResolvedDate { get; set; }

        /// <summary>
        /// Invited user role 
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeUserRole Role { get; set; }

        /// <summary>
        /// Is user external
        /// </summary>
        [JsonProperty("external")]
        public bool External { get; set; }
    }

}

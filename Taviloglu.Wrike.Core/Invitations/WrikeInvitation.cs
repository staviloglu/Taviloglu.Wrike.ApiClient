using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using Taviloglu.Wrike.Core.Extensions;
using Taviloglu.Wrike.Core.Json;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.Core.Invitations
{
    /// <summary>
    /// Invitation
    /// </summary>
    public class WrikeInvitation : WrikeObjectWithId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeInvitation"/> class with email.
        /// </summary>
        /// <param name="email">Create an invitation for email</param>
        /// <param name="firstName">First name of invited user</param>
        /// <param name="lastName">Last name of invited user</param>
        /// <param name="role">Set user role in account</param>
        /// <param name="external">Set external flag for invited user. Flag 'External' can be applied only to the role 'User'</param>
        public WrikeInvitation(string email,
            string firstName = null,
            string lastName = null,
            WrikeUserRole role = WrikeUserRole.User, bool external = false)
        {
            email.ValidateParameter(nameof(email));

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
        public string Email { get; private set; }
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

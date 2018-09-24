using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Taviloglu.Wrike.Core.Users
{
    public sealed class WrikeUserProfile : IWrikeObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="WrikeUserProfile"/> class with accountId, role and external info.
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="role">Role in account</param>
        /// <param name="external">Make user external</param>
        public WrikeUserProfile(string accountId, WrikeUserRole role, bool external = false)
        {
            if (accountId == null)
            {
                throw new ArgumentNullException(nameof(accountId));
            }

            if (accountId.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(accountId));
            }

            AccountId = accountId;
            Role = role;
            External = external;
        }

        /// <summary>
        /// Account ID
        /// </summary>
        [JsonProperty("accountId")]
        public string AccountId { get; private set; }

        /// <summary>
        /// Email address associated with account
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Role in account 
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WrikeUserRole Role { get; private set; }

        /// <summary>
        /// Is user external
        /// </summary>
        [JsonProperty("external")]
        public bool External { get; set; }

        /// <summary>
        /// Is user account admin
        /// </summary>
        [JsonProperty("admin")]
        public bool Admin { get; set; }

        /// <summary>
        /// Is user account owner
        /// </summary>
        [JsonProperty("owner")]
        public bool Owner { get; set; }
    }

}

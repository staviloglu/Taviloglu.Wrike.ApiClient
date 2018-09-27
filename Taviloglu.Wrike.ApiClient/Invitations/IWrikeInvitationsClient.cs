using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Invitations;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Invitation operations
    /// </summary>
    public interface IWrikeInvitationsClient
    {
        /// <summary>
        /// Get all invitations for current account. 
        /// Scopes: amReadOnlyInvitation, amReadWriteInvitation
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-invitations"/>
        Task<List<WrikeInvitation>> GetAsync();

        /// <summary>
        /// Delete invitation by ID.
        /// Scopes: amReadWriteInvitation
        /// </summary>
        /// <param name="id">Invitiation ID</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-invitation"/>        
        Task DeleteAsync(WrikeClientIdParameter id);

        /// <summary>
        ///  Update invitation by ID and/or resend invitation.
        ///  Scopes: amReadWriteInvitation
        /// </summary>
        /// <param name="id">Invitation ID</param>
        /// <param name="external">Change external flag for pending invitation. Flag 'External' can be applied only to the role 'User'</param>
        /// <param name="resend">Resend invitation</param>
        /// <param name="role">Change role of user in account for pending invitation </param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/update-invitation"/>
        Task<WrikeInvitation> UpdateAsync(WrikeClientIdParameter id, bool? resend = null, WrikeUserRole? role = null, bool? external = null);


        /// <summary>
        ///  Create an invitation into the current account.
        ///  Scopes: amReadWriteInvitation
        /// </summary>
        /// <param name="subject">Custom message subject</param>
        /// <param name="message">Custom message body</param>
        /// <param name="newInvitation">Use <see cref="WrikeInvitation.WrikeInvitation(string, string, string, WrikeUserRole, bool)"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-invitation"/>
        Task<WrikeInvitation> CreateAsync(WrikeInvitation newInvitation, string subject = null, string message = null);

    }
}

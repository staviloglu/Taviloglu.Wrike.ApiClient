using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Contact operations
    /// </summary>
    public interface IWrikeContactsClient
    {
        /// <summary>
        /// List contacts of all users and user groups in current account.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="me">If present - only contact info of requesting user is returned</param>
        /// <param name="metadata">Metadata filter, exact match for metadata key or key-value pair</param>
        /// <param name="isDeleted">Deleted flag filter</param>
        /// <param name="retrieveMetadata"></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-contacts"/>
        Task<List<WrikeUser>> GetAsync(
            bool? me = null,
            WrikeMetadata metadata = null,
            bool? isDeleted = null,
            bool? retrieveMetadata = null);


        /// <summary>
        /// List contacts of specified users and user groups.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="contactIds">string list of contactIds</param>
        /// <param name="metadata">Metadata filter, exact match for metadata key or key-value pair</param>
        /// <param name="retrieveMetadata"></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-contacts"/>
        Task<List<WrikeUser>> GetAsync(List<string> contactIds, WrikeMetadata metadata = null, bool? retrieveMetadata = null);

        /// <summary>
        /// Update contact of requesting user by ID (use 'Users.UpdateAsync' method to update other users). Account Admins may use this method to update group info by group ID.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">ContactId / UserId</param>
        /// <param name="metadata">Metadata to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-contact"/>        
        Task<WrikeUser> UpdateAsync(string id, List<WrikeMetadata> metadata = null);
    }
}

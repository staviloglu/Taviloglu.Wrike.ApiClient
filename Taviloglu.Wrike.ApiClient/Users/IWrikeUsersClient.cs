using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// User operations
    /// </summary>
    public interface IWrikeUsersClient
    {
        /// <summary>
        ///  Returns information about single user. 
        ///  Scopes: amReadOnlyUser, amReadWriteUser
        /// </summary>
        /// <param name="id">userId</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-user"/>
        Task<WrikeUser> GetAsync(WrikeClientIdParameter id);

        /// <summary>
        /// Update users by ID (accessible to Admins only).
        /// Scopes: amReadWriteUser
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="profile">Profile to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-user"/>
        Task<WrikeUser> UpdateAsync(WrikeClientIdParameter id, WrikeUserProfile profile);
    }
}

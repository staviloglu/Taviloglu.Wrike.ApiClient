using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeUsersClient
    {
        /// <summary>
        ///  Returns information about single user. 
        ///  Scopes: amReadOnlyUser, amReadWriteUser
        /// </summary>
        /// <param name="id">userId</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-user"/>
        Task<WrikeUser> GetAsync(string id);

        /// <summary>
        /// Update users by ID (accessible to Admins only).
        /// Scopes: amReadWriteUser
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="profile">Profile to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-user"/>
        Task<WrikeUser> UpdateAsync(string id, WrikeUserProfile profile);
    }
}

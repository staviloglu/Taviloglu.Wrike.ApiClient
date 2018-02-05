using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
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
        Task<WrikeResDto<WrikeUser>> GetAsync(string id);
    }
}

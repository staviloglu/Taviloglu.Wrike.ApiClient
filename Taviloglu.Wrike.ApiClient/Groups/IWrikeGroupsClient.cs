using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeGroupsClient
    {
        /// <summary>
        /// Delete group by Id
        /// Scopes: amReadWriteGroup
        /// </summary>
        /// <param name="groupId"></param>  
        /// <param name="isTest">Check that group can be removed</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-groups"/>
        Task<WrikeResDto<WrikeGroup>> DeleteAsync(string groupId, bool isTest = false);
    }
}

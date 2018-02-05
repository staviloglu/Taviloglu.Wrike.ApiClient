using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeColorsClient
    {
        /// <summary>
        /// Get color name - code mapping
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-colors"/>
        Task<WrikeResDto<WrikeColor>> GetAsync();
    }
}

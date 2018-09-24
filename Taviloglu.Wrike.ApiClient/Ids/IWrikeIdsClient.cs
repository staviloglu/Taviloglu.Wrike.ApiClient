using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Ids;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Id operations
    /// </summary>
    public interface IWrikeIdsClient
    {
        /// <summary>
        /// Convert APIv2 legacy IDs to APIv3 format for specific entity type.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/legacy-api-v2-ids-converter"/>
        Task<List<WrikeApiV2Id>> GetAsync(WrikeEntityType entityType, List<int> ids);
    }
}

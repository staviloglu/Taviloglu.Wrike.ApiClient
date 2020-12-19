using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Colors;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Color operations
    /// </summary>
    public interface IWrikeColorsClient
    {
        /// <summary>
        /// Get color name - code mapping
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-colors"/>
        Task<List<WrikeColor>> GetAsync();
    }
}

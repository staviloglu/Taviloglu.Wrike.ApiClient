using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.TimelogCategories;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Timelog Category operations
    /// </summary>
    public interface IWrikeTimelogCategoriesClient
    {
        /// <summary>
        /// Get timelog categories in account.
        /// Scopes: Default, amReadOnlyTimelogCategory, amReadWriteTimelogCategory, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-timelog-categories"/>
        Task<List<WrikeTimelogCategory>> GetAsync();
    }
}

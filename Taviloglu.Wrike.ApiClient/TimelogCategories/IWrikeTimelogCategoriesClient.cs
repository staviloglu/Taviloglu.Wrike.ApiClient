using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.TimelogCategories;

namespace Taviloglu.Wrike.ApiClient.TimeLogCategories
{
    public interface IWrikeTimelogCategoriesClient
    {
        /// <summary>
        /// Get timelog categories in account.
        /// Scopes: Default, wsReadOnly, wsReadWrite, amReadOnlyTimelogCategory, amReadWriteTimelogCategory
        /// </summary>
        /// <param name="id">AccountId</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-timelog-categories"/>
        Task<List<WrikeTimelogCategory>> GetTimelogCategories(string id);
    }
}

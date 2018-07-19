using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.TimeLogCategories;
using Taviloglu.Wrike.Core.TimelogCategories;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTimelogCategoriesClient
    {
        async Task<List<WrikeTimelogCategory>> IWrikeTimelogCategoriesClient.GetTimelogCategories(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null or empty");
            }

            var uriBuilder = new WrikeGetUriBuilder($"accounts/{id}/timelog_categories");

            var response = await SendRequest<WrikeTimelogCategory>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }
        
    }
}

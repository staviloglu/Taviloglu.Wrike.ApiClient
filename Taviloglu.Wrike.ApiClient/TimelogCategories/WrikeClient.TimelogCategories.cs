using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.TimelogCategories;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTimelogCategoriesClient
    {
        public IWrikeTimelogCategoriesClient TimeLogCategories { get { return (IWrikeTimelogCategoriesClient)this; } }

        async Task<List<WrikeTimelogCategory>> IWrikeTimelogCategoriesClient.GetAsync()
        {
            var response = await SendRequest<WrikeTimelogCategory>("timelog_categories", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

    }
}

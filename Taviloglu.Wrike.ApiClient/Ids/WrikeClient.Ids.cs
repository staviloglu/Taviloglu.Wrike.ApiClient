using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Ids;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeIdsClient
    {
        public IWrikeIdsClient Ids
        {
            get
            {
                return (IWrikeIdsClient)this;                
            }
        }

        async Task<List<WrikeId>> IWrikeIdsClient.GetAsync(WrikeEntityType entityType, List<string> ids)
        {
            var requestUri = "ids";

           var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("type", entityType)
                .AddParameter("ids", ids);

            var response = await SendRequest<WrikeId>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }
    }
}

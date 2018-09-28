using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Ids;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeIdsClient
    {
        public IWrikeIdsClient Ids { get { return (IWrikeIdsClient)this; } }
        

        async Task<List<WrikeApiV2Id>> IWrikeIdsClient.GetAsync(WrikeEntityType entityType, List<int> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Count == 0)
            {
                throw new ArgumentException("value can not be empty", nameof(ids));
            }

            var uriBuilder = new WrikeUriBuilder("ids")
                .AddParameter("type", entityType)
                .AddParameter("ids", ids);

            var response = await SendRequest<WrikeApiV2Id>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }
    }
}

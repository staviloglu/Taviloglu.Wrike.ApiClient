using System;
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
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Count == 0)
            {
                throw new ArgumentException("ids can not be empty", nameof(ids));
            }

            var uriBuilder = new WrikeGetUriBuilder("ids")
                .AddParameter("type", entityType)
                .AddParameter("ids", ids);

            var response = await SendRequest<WrikeId>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }
    }
}

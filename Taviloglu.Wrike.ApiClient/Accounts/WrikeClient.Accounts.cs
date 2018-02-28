using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeAccountsClient
    {
        public IWrikeAccountsClient Accounts
        {
            get
            {
                return (IWrikeAccountsClient)this;
            }
        }

        async Task<List<WrikeAccount>> IWrikeAccountsClient.GetAsync(WrikeMetadata metadata, List<string> fields)
        {
            var requestUri = "accounts";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("metadata", metadata).
                AddParameter("fields", fields);

            var response = await SendRequest<WrikeAccount>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        //TODO: implement other methods
    }
}

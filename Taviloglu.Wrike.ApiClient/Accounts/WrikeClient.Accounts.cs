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
                //throw new NotImplementedException("accounts not implemented yet!");
            }
        }

        public async Task<List<WrikeAccount>> GetAsync(WrikeMetadata metadata = null, List<string> fields = null)
        {
            var requestUri = "accounts";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("metadata", metadata).
                AddParameter("fields", fields);

            var response = await SendRequest<WrikeAccount>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        //todo: implement methods
    }
}

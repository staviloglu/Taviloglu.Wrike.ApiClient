using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.TimelogCategories;

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

        async Task<WrikeAccount> IWrikeAccountsClient.GetAsync(WrikeMetadata metadata, List<string> fields)
        {
            var uriBuilder = new WrikeGetUriBuilder("account")
                .AddParameter("metadata", metadata).
                AddParameter("fields", fields);

            var response = await SendRequest<WrikeAccount>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeAccount> IWrikeAccountsClient.UpdateAsync(List<WrikeMetadata> metadataList)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("metadata", metadataList);

            var response = await SendRequest<WrikeAccount>($"account", HttpMethods.Put, contentBuilder.GetContent())
                .ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

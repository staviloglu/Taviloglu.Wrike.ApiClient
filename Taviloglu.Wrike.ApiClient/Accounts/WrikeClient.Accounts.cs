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

        async Task<List<WrikeAccount>> IWrikeAccountsClient.GetAsync(WrikeMetadata metadata, List<string> fields)
        {
            var uriBuilder = new WrikeGetUriBuilder("accounts")
                .AddParameter("metadata", metadata).
                AddParameter("fields", fields);

            var response = await SendRequest<WrikeAccount>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }


        async Task<WrikeAccount> IWrikeAccountsClient.GetAsync(string id, List<string> fields)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null or empty");
            }

            var uriBuilder = new WrikeGetUriBuilder($"accounts/{id}")
                .AddParameter("fields", fields);

            var response = await SendRequest<WrikeAccount>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeAccount> IWrikeAccountsClient.UpdateAsync(string id, List<WrikeMetadata> metadataList)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null or empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("metadata", metadataList);

            var response = await SendRequest<WrikeAccount>($"accounts/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        async Task<List<WrikeTimelogCategory>> IWrikeAccountsClient.GetTimelogCategories(string id)
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

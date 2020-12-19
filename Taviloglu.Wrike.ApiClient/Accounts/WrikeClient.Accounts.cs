using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Accounts;

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

        async Task<WrikeAccount> IWrikeAccountsClient.GetAsync(WrikeMetadata metadata, List<string> optionalFields)
        {
            if (optionalFields!= null && optionalFields.Count> 0 && optionalFields.Except(WrikeAccount.OptionalFields.List).Any())
            {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeAccount.OptionalFields");
            }

            var uriBuilder = new WrikeUriBuilder("account")
                .AddParameter("metadata", metadata).
                AddParameter("fields", optionalFields);

            var response = await SendRequest<WrikeAccount>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeAccount> IWrikeAccountsClient.UpdateAsync(List<WrikeMetadata> metadataList)
        {
            if (metadataList == null)
            {
                throw new ArgumentNullException(nameof(metadataList));
            }

            if (metadataList.Count == 0)
            {
                throw new ArgumentException("value can not be empty", nameof(metadataList));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("metadata", metadataList);

            var response = await SendRequest<WrikeAccount>($"account", HttpMethods.Put, contentBuilder.GetContent())
                .ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeContactsClient
    {
        public IWrikeContactsClient Contacts
        {
            get
            {
                return (IWrikeContactsClient)this;
            }
        }

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(string accountId, bool? me, WrikeMetadata metadata, bool? retrieveMetadata)
        {
            var requestUri = "contacts";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/contacts";
            }



            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("me", me)
                .AddParameter("metadata", metadata);

            if (retrieveMetadata.HasValue && retrieveMetadata == true)
            {
                var fields = new List<string> { "metadata" };
                uriBuilder.AddParameter("fields", fields);
            }

            var response = await SendRequest<WrikeUser>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(List<string> contactIds, WrikeMetadata metadata, bool? retrieveMetadata)
        {
            if (contactIds == null || contactIds.Count < 1)
            {
                throw new ArgumentNullException("contactIds can not be null or empty");
            }
            if (contactIds.Count > 100)
            {
                throw new ArgumentException("contactIds max count is 100");
            }

            var contactIdsValue = string.Join(",", contactIds);
            var requestUri = $"customfields/{contactIdsValue}";
            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("metadata", metadata);
            if (retrieveMetadata.HasValue && retrieveMetadata == true)
            {
                var fields = new List<string> { "metadata" };
                uriBuilder.AddParameter("fields", fields);
            }

            var response = await SendRequest<WrikeUser>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(WrikeUserType type, string accountId, bool? me, WrikeMetadata metadata, bool? retrieveMetadata)
        {
            var contacts =  await Contacts.GetAsync(accountId, me, metadata, retrieveMetadata);
            return contacts.Where(c => c.Type == type).ToList();
        }

        async Task<WrikeUser> IWrikeContactsClient.UpdateAsync(string id, List<WrikeMetadata> metadata)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("metadata", metadata);

            var response = await SendRequest<WrikeUser>($"contacts/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

using System;
using System.Collections.Generic;
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

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(bool? me, WrikeMetadata metadata, bool? isDeleted, bool? retrieveMetadata)
        {
            var requestUri = "contacts";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("me", me)
                .AddParameter("metadata", metadata)
                .AddParameter("deleted", isDeleted);

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
            if (contactIds == null)
            {
                throw new ArgumentNullException(nameof(contactIds));
            }

            if (contactIds.Count == 0)
            {
                throw new ArgumentException("contactIds can not be empty", nameof(contactIds));
            }

            if (contactIds.Count > 100)
            {
                throw new ArgumentException("Max. 100 contactIds can be used", nameof(contactIds));
            }

            var contactIdsValue = string.Join(",", contactIds);
            var requestUri = $"contacts/{contactIdsValue}";
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

        async Task<WrikeUser> IWrikeContactsClient.UpdateAsync(string id, List<WrikeMetadata> metadata)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException("id can not be empty", nameof(id));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("metadata", metadata);

            var response = await SendRequest<WrikeUser>($"contacts/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

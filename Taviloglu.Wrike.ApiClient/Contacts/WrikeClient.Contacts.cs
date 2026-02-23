using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeContactsClient
    {
        public IWrikeContactsClient Contacts { get { return (IWrikeContactsClient)this; } }

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(bool? me, WrikeMetadata metadata, bool? isDeleted, bool? retrieveMetadata, List<string> fields = null)
        {
            var requestUri = "contacts";

            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("me", me)
                .AddParameter("metadata", metadata)
                .AddParameter("deleted", isDeleted);

            if (fields != null)
            {
                if (retrieveMetadata.HasValue && retrieveMetadata == true && !fields.Contains("metadata"))
                {
                    fields.Add("metadata");
                }
                uriBuilder.AddParameter("fields", fields);
            }
            else if (retrieveMetadata.HasValue && retrieveMetadata == true)
            {
                var metadataFields = new List<string> { "metadata" };
                uriBuilder.AddParameter("fields", metadataFields);
            }

            var response = await SendRequest<WrikeUser>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(WrikeClientIdListParameter contactIds, WrikeMetadata metadata, bool? retrieveMetadata, List<string> fields = null)
        {
            var requestUri = $"contacts/{contactIds}";
            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("metadata", metadata);

            if (fields != null)
            {
                if (retrieveMetadata.HasValue && retrieveMetadata == true && !fields.Contains("metadata"))
                {
                    fields.Add("metadata");
                }
                uriBuilder.AddParameter("fields", fields);
            }
            else if (retrieveMetadata.HasValue && retrieveMetadata == true)
            {
                var metadataFields = new List<string> { "metadata" };
                uriBuilder.AddParameter("fields", metadataFields);
            }

            var response = await SendRequest<WrikeUser>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeUser> IWrikeContactsClient.UpdateAsync(WrikeClientIdParameter id, List<WrikeMetadata> metadata)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("metadata", metadata);

            var response = await SendRequest<WrikeUser>($"contacts/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

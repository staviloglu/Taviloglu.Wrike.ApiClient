using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeContactsClient
    {
        public IWrikeContactsClient Contacts { get { return (IWrikeContactsClient)this; } }        

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(bool? me, WrikeMetadata metadata, bool? isDeleted, bool? retrieveMetadata)
        {
            var requestUri = "contacts";

            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("metadata", metadata)
                .AddParameter("deleted", isDeleted);
                
            if (me == true) {
                uriBuilder.AddParameter("me", me);
            }

            if (retrieveMetadata.HasValue && retrieveMetadata == true)
            {
                var fields = new List<string> { "metadata" };
                uriBuilder.AddParameter("fields", fields);
            }

            var response = await SendRequest<WrikeUser>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeUser>> IWrikeContactsClient.GetAsync(WrikeClientIdListParameter contactIds, WrikeMetadata metadata, bool? retrieveMetadata)
        {
            var requestUri = $"contacts/{contactIds}";
            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("metadata", metadata);
            if (retrieveMetadata.HasValue && retrieveMetadata == true)
            {
                var fields = new List<string> { "metadata" };
                uriBuilder.AddParameter("fields", fields);
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

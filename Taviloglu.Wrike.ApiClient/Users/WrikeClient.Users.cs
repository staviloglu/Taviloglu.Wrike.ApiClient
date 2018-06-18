using System;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeUsersClient
    {
        public IWrikeUsersClient Users
        {
            get
            {
                return (IWrikeUsersClient)this;
            }
        }
        async Task<WrikeUser> IWrikeUsersClient.GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null or empty");
            }

            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeUser> IWrikeUsersClient.UpdateAsync(string id, WrikeUserProfile profile)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null or empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("profile", profile);

            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

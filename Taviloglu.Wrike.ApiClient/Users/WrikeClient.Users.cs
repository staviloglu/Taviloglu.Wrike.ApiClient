using System;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeUsersClient
    {
        public IWrikeUsersClient Users { get { return (IWrikeUsersClient)this; } }         

        async Task<WrikeUser> IWrikeUsersClient.GetAsync(WrikeClientIdParameter id)
        {
            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeUser> IWrikeUsersClient.UpdateAsync(WrikeClientIdParameter id, WrikeUserProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("profile", profile);

            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

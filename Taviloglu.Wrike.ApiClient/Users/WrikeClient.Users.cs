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
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException("id can not be empty", nameof(id));
            }

            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeUser> IWrikeUsersClient.UpdateAsync(string id, WrikeUserProfile profile)
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
                .AddParameter("profile", profile);

            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

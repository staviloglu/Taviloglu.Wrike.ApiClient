using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
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
            var response = await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get);
            return GetReponseDataFirstItem(response);
        }
    }
}

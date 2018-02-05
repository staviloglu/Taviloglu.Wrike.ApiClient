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
        async Task<WrikeResDto<WrikeUser>> IWrikeUsersClient.GetAsync(string id)
        {
            return await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get);
        }
    }
}

using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeColorsClient
    {
        public IWrikeColorsClient Colors
        {
            get
            {
                return (IWrikeColorsClient)this;
            }
        }
        async Task<WrikeResDto<WrikeColor>> IWrikeColorsClient.GetAsync()
        {
            return await SendRequest<WrikeColor>("colors", HttpMethods.Get);
        }
    }
}

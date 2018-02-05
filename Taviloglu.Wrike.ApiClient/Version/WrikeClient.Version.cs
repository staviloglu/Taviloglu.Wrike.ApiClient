using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeVersionClient
    {
        public IWrikeVersionClient Version
        {
            get
            {
                return (IWrikeVersionClient)this;
            }
        }

        async Task<WrikeResDto<WrikeVersion>> IWrikeVersionClient.GetAsync()
        {
            return await SendRequest<WrikeVersion>("version", HttpMethods.Get);
        }
    }
}

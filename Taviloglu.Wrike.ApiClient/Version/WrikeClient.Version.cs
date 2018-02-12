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

        async Task<WrikeVersion> IWrikeVersionClient.GetAsync()
        {
            var response = await SendRequest<WrikeVersion>("version", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

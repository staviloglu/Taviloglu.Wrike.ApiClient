using System.Collections.Generic;
using System.Threading.Tasks;
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

        async Task<List<WrikeColor>> IWrikeColorsClient.GetAsync()
        {
            var response = await SendRequest<WrikeColor>("colors", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }
    }
}

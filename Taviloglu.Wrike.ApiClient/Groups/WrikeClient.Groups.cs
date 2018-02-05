using System;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeGroupsClient
    {
        public IWrikeGroupsClient Groups
        {
            get
            {
                return (IWrikeGroupsClient)this;
            }

        }
        async Task<WrikeResDto<WrikeGroup>> IWrikeGroupsClient.DeleteAsync(string groupId, bool isTest)
        {
            if (string.IsNullOrWhiteSpace(groupId))
            {
                throw new ArgumentNullException("groupId can not be null or empty");
            }

            var requestUri = $"groups/{groupId}";
            if (isTest)
            {
                requestUri += "?test=true";

            }
            return await SendRequest<WrikeGroup>(requestUri, HttpMethods.Delete);
        }
    }
}

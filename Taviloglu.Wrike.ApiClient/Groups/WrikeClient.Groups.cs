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
        async Task IWrikeGroupsClient.DeleteAsync(string groupId, bool isTest)
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
            var response = await SendRequest<WrikeGroup>(requestUri, HttpMethods.Delete).ConfigureAwait(false);
            //TODO: anything to do with the response?
            return;
        }
    }
}

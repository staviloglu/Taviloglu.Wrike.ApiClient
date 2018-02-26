using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeWorkflowsClient
    {
        public IWrikeWorkflowsClient Workflows
        {
            get
            {
                return (IWrikeWorkflowsClient)this;
            }
        }

        async Task<WrikeWorkflow> IWrikeWorkflowsClient.CreateAsync(string accountId, string name)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException(nameof(accountId));
            }


            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));

            }

            var requestUri = $"accounts/{accountId}/workflows";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("name", name);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeWorkflow>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        async Task<List<WrikeWorkflow>> IWrikeWorkflowsClient.GetAsync(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException(nameof(accountId));
            }

            var response = await SendRequest<WrikeWorkflow>($"accounts/{accountId}/workflows", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }
    }
}

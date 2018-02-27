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

        async Task<WrikeWorkflow> IWrikeWorkflowsClient.CreateAsync(string accountId, WrikeWorkflow newWorkflow)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException(nameof(accountId));
            }


            if (string.IsNullOrWhiteSpace(newWorkflow.Name))
            {
                throw new ArgumentNullException(nameof(newWorkflow.Name));

            }

            var requestUri = $"accounts/{accountId}/workflows";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("name", newWorkflow.Name);

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

        async Task<WrikeWorkflow> IWrikeWorkflowsClient.UpdateAsync(string workflowId, string name, bool? isHidden, WrikeCustomStatus customStatus)
        {
            if (string.IsNullOrWhiteSpace(workflowId))
            {
                throw new ArgumentNullException(nameof(workflowId));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
               .AddParameter("name", name)
               .AddParameter("hidden", isHidden)
               .AddParameter("customStatus", customStatus);

            var response = await SendRequest<WrikeWorkflow>($"workflows/{workflowId}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

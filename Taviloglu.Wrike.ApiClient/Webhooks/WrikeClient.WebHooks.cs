using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeWebhooksClient
    {
        public IWrikeWebhooksClient Webhooks
        {
            get
            {
                return (IWrikeWebhooksClient)this;
            }
        }
        async Task<WrikeWebhook> IWrikeWebhooksClient.CreateAsync(WrikeWebhook newWebhook)
        {
            if (newWebhook == null)
            {
                throw new ArgumentNullException("newWebhook can not be null");
            }
            if (string.IsNullOrWhiteSpace(newWebhook.AccountId))
            {
                throw new ArgumentNullException("newWebhook.AccountId can not be null or empty");
            }

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("hookUrl", newWebhook.HookUrl);


            var response = await SendRequest<WrikeWebhook>($"accounts/{newWebhook.AccountId}/webhooks",
                HttpMethods.Post, postDataBuilder.GetContent());

            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeWebhooksClient.DeleteAsync(string webhookId)
        {
            if (string.IsNullOrWhiteSpace(webhookId))
            {
                throw new ArgumentNullException("webhookId can not be null or empty");
            }

            var response = await SendRequest<WrikeWebhook>($"webhooks/{webhookId}", HttpMethods.Delete);
        }
        
        async Task<List<WrikeWebhook>> IWrikeWebhooksClient.GetAsync(string accountId)
        {
            var requestUri = $"webhooks";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/webhooks";
            }

            var response = await SendRequest<WrikeWebhook>(requestUri, HttpMethods.Get);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeWebhook>> IWrikeWebhooksClient.GetAsync(List<string> webhookIds)
        {
            if (webhookIds == null || webhookIds.Count < 1)
            {
                throw new ArgumentNullException("webhookIds can not be null or empty");
            }
            if (webhookIds.Count > 100)
            {
                throw new ArgumentException("webhookIds max count is 100");
            }

            var webhookIdsValue = string.Join(",", webhookIds);
            var response = await SendRequest<WrikeWebhook>($"webhooks/{webhookIdsValue}", HttpMethods.Get);
            return GetReponseDataList(response);
        }

        async Task<WrikeWebhook> IWrikeWebhooksClient.UpdateAsync(string webhookId, WrikeWebhookStatus status)
        {
            if (string.IsNullOrWhiteSpace(webhookId))
            {
                throw new ArgumentException("webhookId can not be null or empty");
            }

            var putDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("status", status);

            var response = await SendRequest<WrikeWebhook>($"webhooks/{webhookId}", HttpMethods.Put, putDataBuilder.GetContent());

            return GetReponseDataFirstItem(response);
        }
    }
}

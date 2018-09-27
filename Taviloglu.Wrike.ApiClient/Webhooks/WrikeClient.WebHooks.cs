using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Webhooks;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeWebHooksClient
    {
        public IWrikeWebHooksClient WebHooks
        {
            get
            {
                return (IWrikeWebHooksClient)this;
            }
        }
        async Task<WrikeWebHook> IWrikeWebHooksClient.CreateAsync(WrikeWebHook newWebHook, string folderId)
        {
            if (newWebHook == null)
            {
                throw new ArgumentNullException("newWebhook can not be null");
            }

            if (string.IsNullOrWhiteSpace(newWebHook.AccountId))
            {
                throw new ArgumentNullException("newWebhook.AccountId can not be null or empty");
            }

            var uri = $"accounts/{newWebHook.AccountId}/webhooks";

            if (!string.IsNullOrWhiteSpace(folderId))
            {
                uri = $"folders/{folderId}/webhooks";
            }
           
            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("hookUrl", newWebHook.HookUrl);


            var response = await SendRequest<WrikeWebHook>(uri,
                HttpMethods.Post, postDataBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeWebHooksClient.DeleteAsync(string webHookId)
        {
            if (string.IsNullOrWhiteSpace(webHookId))
            {
                throw new ArgumentNullException("webHookId can not be null or empty");
            }

            var response = await SendRequest<WrikeWebHook>($"webhooks/{webHookId}", HttpMethods.Delete).ConfigureAwait(false);
        }
        
        async Task<List<WrikeWebHook>> IWrikeWebHooksClient.GetAsync(string accountId)
        {
            var requestUri = $"webhooks";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/webhooks";
            }

            var response = await SendRequest<WrikeWebHook>(requestUri, HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeWebHook>> IWrikeWebHooksClient.GetAsync(List<string> webHookIds)
        {
            if (webHookIds == null || webHookIds.Count < 1)
            {
                throw new ArgumentNullException("webhookIds can not be null or empty");
            }
            if (webHookIds.Count > 100)
            {
                throw new ArgumentException("webhookIds max count is 100");
            }

            var webHookIdsValue = string.Join(",", webHookIds);
            var response = await SendRequest<WrikeWebHook>($"webhooks/{webHookIdsValue}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeWebHook> IWrikeWebHooksClient.UpdateAsync(string webHookId, WrikeWebHookStatus status)
        {
            if (string.IsNullOrWhiteSpace(webHookId))
            {
                throw new ArgumentException("webhookId can not be null or empty");
            }

            var putDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("status", status);

            var response = await SendRequest<WrikeWebHook>($"webhooks/{webHookId}", HttpMethods.Put, putDataBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }
    }
}

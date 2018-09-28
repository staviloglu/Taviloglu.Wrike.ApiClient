using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.WebHooks;

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
        async Task<WrikeWebHook> IWrikeWebHooksClient.CreateAsync(WrikeClientIdParameter folderId, WrikeWebHook newWebHook)
        {
            if (newWebHook == null)
            {
                throw new ArgumentNullException(nameof(newWebHook));
            }
           
            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("hookUrl", newWebHook.HookUrl);


            var response = await SendRequest<WrikeWebHook>($"folders/{folderId}/webhooks",
                HttpMethods.Post, postDataBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeWebHooksClient.DeleteAsync(WrikeClientIdParameter webHookId)
        {
            var response = await SendRequest<WrikeWebHook>($"webhooks/{webHookId}", HttpMethods.Delete).ConfigureAwait(false);
        }
        
        async Task<List<WrikeWebHook>> IWrikeWebHooksClient.GetAsync()
        {
            var response = await SendRequest<WrikeWebHook>("webhooks", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeWebHook>> IWrikeWebHooksClient.GetAsync(WrikeClientIdListParameter webHookIds)
        {            
            var response = await SendRequest<WrikeWebHook>($"webhooks/{webHookIds}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeWebHook> IWrikeWebHooksClient.UpdateAsync(WrikeClientIdParameter webHookId, WrikeWebHookStatus status)
        {
            var putDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("status", status);

            var response = await SendRequest<WrikeWebHook>($"webhooks/{webHookId}", HttpMethods.Put, putDataBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }
    }
}

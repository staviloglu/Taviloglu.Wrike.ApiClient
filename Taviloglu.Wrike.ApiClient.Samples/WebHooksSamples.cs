using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class WebHooksSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var webhooks = await client.WebHooks.GetAsync("accountId");

            webhooks = await client.WebHooks.GetAsync(new List<string> { "webhookId", "webhookId" });

            webhooks = await client.WebHooks.GetAsync();

            var newWebhook = new WrikeWebHook("accountId", "http://google.com");
            newWebhook = await client.WebHooks.CreateAsync(newWebhook);

            newWebhook = await client.WebHooks.UpdateAsync(newWebhook.Id, WrikeWebHookStatus.Suspended);

            await client.WebHooks.DeleteAsync(newWebhook.Id);

        }
    }
}

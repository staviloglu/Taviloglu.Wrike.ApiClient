using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.Samples
{
    public static class WebhooksSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var webhooks = await client.Webhooks.GetAsync("accountId");

            webhooks = await client.Webhooks.GetAsync(new List<string> { "webhookId", "webhookId" });

            webhooks = await client.Webhooks.GetAsync();

            var newWebhook = new WrikeWebhook("accountId", "http://google.com");
            newWebhook = await client.Webhooks.CreateAsync(newWebhook);

            newWebhook = await client.Webhooks.UpdateAsync(newWebhook.Id, WrikeWebhookStatus.Suspended);

            await client.Webhooks.DeleteAsync(newWebhook.Id);

        }
    }
}

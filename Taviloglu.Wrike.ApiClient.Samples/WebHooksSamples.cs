using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Webhooks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class WebHooksSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var webhooks = await client.WebHooks.GetAsync("IEABX2HE");


            var newWebhook = await client.WebHooks.UpdateAsync(webhooks[0].Id, WrikeWebHookStatus.Active);





            //webhooks = await client.WebHooks.GetAsync(new List<string> { "webhookId", "webhookId" });



            //webhooks = await client.WebHooks.GetAsync();

            //var newWebhook = new WrikeWebHook("IEABX2HE", "https://wrike.adcitymedia.com/api/WrikeWebHook");
            //newWebhook = await client.WebHooks.CreateAsync(newWebhook);

            //webhooks = await client.WebHooks.GetAsync();

            

            //await client.WebHooks.DeleteAsync(newWebhook.Id);

        }
    }
}

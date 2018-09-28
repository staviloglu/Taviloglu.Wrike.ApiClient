using System.Threading.Tasks;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class WebHooksSamples
    {
        //Thanks to @fredsted
        //https://github.com/fredsted/webhook.site
        //https://webhook.site/#/ca5bbc32-9f4c-433c-a8d4-be18041def50/3e31dc6c-0a28-457e-b292-600f39e392c8/0
        const string TestWebHookAddress = "https://webhook.site/ca5bbc32-9f4c-433c-a8d4-be18041def50";


        public static async Task Run(WrikeClient client)
        {
            var webhooks = await client.WebHooks.GetAsync();

            //var webhooks = await client.WebHooks.GetAsync(new List<string> { "webHookId", "webHookId"});


            var newWebHook = new WrikeWebHook(TestWebHookAddress);
            newWebHook = await client.WebHooks.CreateAsync(newWebHook);

            //var newWebHook = new WrikeWebHook(TestWebHookAddress, "folderID");
            //newWebHook = await client.WebHooks.CreateAsync(newWebHook);


            newWebHook = await client.WebHooks.UpdateAsync(newWebHook.Id, WrikeWebHookStatus.Suspended);

            await client.WebHooks.DeleteAsync(newWebHook.Id);
        }
    }
}

## WebHooks Usage [![NuGet](https://img.shields.io/nuget/v/Taviloglu.Wrike.WebHook.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.WebHook/) [![NuGet Downloads](https://img.shields.io/nuget/dt/Taviloglu.Wrike.WebHook.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.WebHook/)
Create your WrikeWebHookController by subclassing and implementing [WrikeWebHookControllerBase](Taviloglu.Wrike.WebHook/Controllers/WrikeWebHookControllerBase.cs) abstract class provided in [Taviloglu.Wrike.WebHook](Taviloglu.Wrike.WebHook) library. Don't forget to set a route to your new controller. 

```csharp
    [Route("api/[controller]")]
    public class WrikeWebHookController : WrikeWebHookControllerBase
    {
        protected override void OnAttachmentAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }
        
        /*
            implement other events...
        */
     }
```
When your WrikeWebHookController is ready for responding to post requests, create a webhook using the Wrike Client
```csharp
//create client
var client = new WrikeClient("permanent_token");
//create new webhook
//https://developers.wrike.com/documentation/webhooks
var newWebHook = new WrikeWebHook("https://<your-host>/api/wrikewebhook");
newWebHook = await client.WebHooks.CreateAsync(newWebHook);
```
Then Wrike will send post requests to the url you provided. For more details check out [wrike's documentation](https://developers.wrike.com/documentation/webhooks)

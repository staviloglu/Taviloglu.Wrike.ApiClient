# Taviloglu.Wrike.WebHook [![Build Status](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient.svg?branch=master)](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient/) [![BCH compliance](https://bettercodehub.com/edge/badge/staviloglu/Taviloglu.Wrike.ApiClient?branch=master)](https://bettercodehub.com/)

Feel free to show your ❤️ by giving a ⭐ and / or &nbsp;  [![](https://img.shields.io/static/v1?label=sponsoring&message=%E2%9D%A4&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/staviloglu) &nbsp; my coffe expenses

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
Then Wrike will send post requests to the url you provided. For more details check out [wrike's documentation](https://developers.wrike.com/webhooks/)

---

**Note:** WrikeWebHook library uses Newtonsoft.json serializer, which is not default serializer on ASP.NET Core 3.0+ or Framework 5.0+ versions. On recent ASP.NET projects you may need to install Microsoft.AspNetCore.Mvc.NewtonsoftJson package and activate it as follows;
```csharp
services.AddControllers().AddNewtonsoftJson();
```
See [Issue#33](https://github.com/staviloglu/Taviloglu.Wrike.ApiClient/issues/33)

---

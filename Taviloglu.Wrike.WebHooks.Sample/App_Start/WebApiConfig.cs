using Microsoft.AspNet.WebHooks.Controllers;
using System.Web.Http;

namespace Taviloglu.Wrike.WebHooks
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var type = typeof(WebHookReceiversController);
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Initialize MyGet WebHook receiver
            // Web API configuration and services
            //config.InitializeReceiveWrikeWebHooks();
            config.InitializeReceiveDropboxWebHooks();

            config.EnsureInitialized();
        }
    }
}

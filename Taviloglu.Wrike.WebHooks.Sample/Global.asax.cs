using System.Web.Http;

namespace Taviloglu.Wrike.WebHooks.Sample
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

    }
}
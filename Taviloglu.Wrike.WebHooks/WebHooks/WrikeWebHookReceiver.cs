using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace Taviloglu.Wrike.WebHooks
{
    
    public class WrikeWebHookReceiver : WebHookReceiver
    {
        internal const string RecName = "wrike";

        internal const string TypePropertyName = "eventType";
        /// <summary>
        /// Gets the receiver name for this receiver.
        /// </summary>
        public static string ReceiverName
        {
            get { return RecName; }
        }

        /// <inheritdoc />
        public override string Name
        {
            get { return RecName; }
        }

        public override async Task<HttpResponseMessage> ReceiveAsync(string id, HttpRequestContext context, HttpRequestMessage request)
        {

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Method != HttpMethod.Post)
            {
                return CreateBadMethodResponse(request);
            }

            EnsureSecureConnection(request);

            //wrike webhook does not support any kind of verification

            // Read the request entity body
            var data = await ReadAsJsonAsync(request);

            // Read the action from data
            string actionAsString;
            if (!data.TryGetValue(TypePropertyName, out var action))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "unknown payload");                
            }

            actionAsString = action.Value<string>();            

            //might use actions for different events
            return await ExecuteWebHookAsync(id, context, request, new[] { actionAsString }, data);
        }
    }
}

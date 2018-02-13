using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Microsoft.AspNet.WebHooks;

namespace Taviloglu.Wrike.WebHooks
{
    
    public class WrikeWebHookReceiver : WebHookReceiver
    {
        internal const string RecName = "wrike";

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

            // Call registered handlers
            //TODO: try harder to finish! 
            return await ExecuteWebHookAsync(id, context, request, null, data);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.Net;

namespace Taviloglu.Wrike.WebHook.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsLocal(this HttpRequest req)
        {
            var connection = req.HttpContext.Connection;
            if (connection.RemoteIpAddress != null)
            {
                if (IPAddress.IsLoopback(connection.RemoteIpAddress))
                {
                    return true;
                }

                if (connection.RemoteIpAddress.Equals(connection.LocalIpAddress))
                {
                    return true;
                }
            }

            // for in memory TestServer or when dealing with default connection info
            if (connection.RemoteIpAddress == null && connection.LocalIpAddress == null)
            {
                return true;
            }

            return false;
        }
    }
}
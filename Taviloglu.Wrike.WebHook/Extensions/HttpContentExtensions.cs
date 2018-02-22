using System;
using System.ComponentModel;
using System.Net.Http;

namespace Taviloglu.Wrike.WebHook.Extensions
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class HttpContentExtensions
    {
        public static bool IsJson(this HttpContent content)
        {
            if (content.Headers == null || content.Headers.ContentType == null || content.Headers.ContentType.MediaType == null)
            {
                return false;
            }

            string mediaType = content.Headers.ContentType.MediaType;
            return string.Equals(mediaType, "application/json", StringComparison.OrdinalIgnoreCase)
                || string.Equals(mediaType, "text/json", StringComparison.OrdinalIgnoreCase)
                || ((mediaType.StartsWith("application/", StringComparison.OrdinalIgnoreCase) || mediaType.StartsWith("text/", StringComparison.OrdinalIgnoreCase))
                    && mediaType.EndsWith("+json", StringComparison.OrdinalIgnoreCase));
        }

    }
}

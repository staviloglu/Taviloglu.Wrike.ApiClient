using System;

namespace Taviloglu.Wrike.WebHook.Extensions
{
    public static class UriExtensions
    {
        public static bool IsHttps(this Uri input)
        {
            return input != null && input.IsAbsoluteUri && string.Equals(input.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
        }
    }
}
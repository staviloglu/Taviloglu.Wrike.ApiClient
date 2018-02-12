using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;

namespace Taviloglu.Wrike.Samples
{
    public static class VersionSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var version = await client.Version.GetAsync();  
        }
    }
}

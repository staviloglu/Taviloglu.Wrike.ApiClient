using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class VersionSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var version = await client.Version.GetAsync();  
        }
    }
}

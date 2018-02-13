using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class ColorSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var colors = await client.Colors.GetAsync();
        }
    }
}

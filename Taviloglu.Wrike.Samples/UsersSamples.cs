using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class UsersSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var user = await client.Users.GetAsync("userId");
        }
    }
}

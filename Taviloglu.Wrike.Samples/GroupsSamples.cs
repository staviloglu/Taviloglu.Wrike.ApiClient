using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class GroupsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            await client.Groups.DeleteAsync("groupId", true);

            await client.Groups.DeleteAsync("groupId");
        }
    }
}

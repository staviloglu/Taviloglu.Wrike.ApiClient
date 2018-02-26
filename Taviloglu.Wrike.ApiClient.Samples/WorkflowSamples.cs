using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class WorkflowSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var workflows = await client.Workflows.GetAsync("IEABX2HE");
        }
    }
}

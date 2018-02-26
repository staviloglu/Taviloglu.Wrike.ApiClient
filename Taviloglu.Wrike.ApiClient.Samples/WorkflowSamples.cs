using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class WorkflowSamples
    {
        public static async Task Run(WrikeClient client)
        {
            string accountId = "IEABX2HE";
            var workflows = await client.Workflows.GetAsync(accountId);

            var newWorkFlow = new WrikeWorkflow("MyNewWorkflow");

            var newWorkflow = await client.Workflows.CreateAsync(accountId, newWorkFlow);

            var updatedWorkflow = await client.Workflows.UpdateAsync(newWorkflow.Id,
                "UpdatedWorkFlow", false, new Core.WrikeCustomStatus {

                    Color = Core.WrikeColor.CustomStatusColor.Green,
                    Name = "CustomStatus01",
                    Hidden = false,
                    Standard = false,
                    Group = WrikeTaskStatus.Active                    
                });

            updatedWorkflow = await client.Workflows.UpdateAsync(newWorkflow.Id,
                "UpdatedWorkFlow2");


        }
    }
}

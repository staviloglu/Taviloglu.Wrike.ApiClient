using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class WorkflowSamples
    {
        public static async Task Run(WrikeClient client)
        {
            //var workflows = await client.Workflows.GetAsync(accountId);

            //var newWorkFlow = new WrikeWorkflow("MyNewWorkflow");

            //var newWorkflow = await client.Workflows.CreateAsync(accountId, newWorkFlow);

            //var updatedWorkflow = await client.Workflows.UpdateAsync(newWorkflow.Id,
            //    "UpdatedWorkFlow", false, new Core.WrikeCustomStatus {

            //        Color = Core.WrikeColor.CustomStatusColor.Green,
            //        Name = "CustomStatus01",
            //        Hidden = false,
            //        Standard = false,
            //        Group = WrikeTaskStatus.Active                    
            //    });

            //updatedWorkflow = await client.Workflows.UpdateAsync(newWorkflow.Id,
            //    "UpdatedWorkFlow2");

            await ExtensionSamples(client);

        }

        public static async Task ExtensionSamples(WrikeClient client)
        {
            var newWorkflow = new WrikeWorkflow("Sinan's Extension Workflow")
            {
                CustomStatuses = new List<WrikeCustomStatus>
                {
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.Blue,
                        Group = WrikeTaskStatus.Active,
                        Hidden = false,
                        Name = "New"
                    },
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.Brown,
                        Group = WrikeTaskStatus.Active,
                        Hidden = false,
                        Name = "In Progress(MaterialCollector)"
                    },
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.DarkBlue,
                        Group = WrikeTaskStatus.Active,
                        Hidden = false,
                        Name = "Collection Completed"
                    }
                    ,
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.DarkCyan,
                        Group = WrikeTaskStatus.Active,
                        Hidden = false,
                        Name = "Assigned To Content Manager"
                    },
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.DarkBlue,
                        Group = WrikeTaskStatus.Active,
                        Hidden = false,
                        Name = "In Progress(Content Manager)"
                    },
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.Gray,
                        Group = WrikeTaskStatus.Completed,
                        Hidden = false,
                        Name = "Completed"
                    },
                    new WrikeCustomStatus
                    {
                        Color = WrikeColor.CustomStatusColor.DarkBlue,
                        Group = WrikeTaskStatus.Completed,
                        Hidden = false,
                        Name = "BookAndAdApproved"
                    }
                }
            };

            newWorkflow = await client.Workflows.CreateWorkflowWithCustomStatusesAsync(newWorkflow);
        }
    }
}

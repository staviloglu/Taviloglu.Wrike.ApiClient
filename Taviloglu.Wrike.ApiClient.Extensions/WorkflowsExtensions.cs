using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class WorkflowsExtensions
    {
        /// <summary>
        /// Creates new workflow with given customStatuses, by calling create and update methods
        /// </summary>
        /// <param name="wrikeWorkflowsClient">workflow client</param>
        /// <param name="accountId">accountId</param>
        /// <param name="newWorkflow">new workflow to be created with customStatuses set</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-workflow"/>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-workflow"/>
        public static async Task<WrikeWorkflow> CreateWorkflowWithCustomStatusesAsync(this IWrikeWorkflowsClient wrikeWorkflowsClient, string accountId, WrikeWorkflow newWorkflow) {

            if (newWorkflow == null || newWorkflow.CustomStatuses == null || newWorkflow.CustomStatuses.Count <  1)
            {
                throw new ArgumentException("newWorkflow.CustomStatuses count should be greater than zero", nameof(newWorkflow.CustomStatuses));
            }

            if (newWorkflow.CustomStatuses.Any(cs=> cs.Id != null))
            {
                throw new ArgumentException("newWorkflow.CustomStatuses can not have Id property set", nameof(newWorkflow.CustomStatuses));
            }

            var createdWorkflow = await wrikeWorkflowsClient.CreateAsync(accountId, newWorkflow);
            
            //created workflow will have default active and completed statuses, if newWorkflow.CustomStatuses
            //have same items update the default ones

            var firstActiveCustomStatus =
                newWorkflow.CustomStatuses.FirstOrDefault(cs => cs.Group == WrikeTaskStatus.Active);
            if (firstActiveCustomStatus != null)
            {
                firstActiveCustomStatus.Id = createdWorkflow.CustomStatuses.FirstOrDefault(cs => cs.Group == WrikeTaskStatus.Active).Id;
                firstActiveCustomStatus.Group = null;
            }

            var firstCompletedCustomStatus = newWorkflow.CustomStatuses.FirstOrDefault(cs => cs.Group == WrikeTaskStatus.Completed);
            if (firstActiveCustomStatus != null)
            {
                firstCompletedCustomStatus.Id = createdWorkflow.CustomStatuses.FirstOrDefault(cs => cs.Group == WrikeTaskStatus.Completed).Id;
                firstCompletedCustomStatus.Group = null;                
            }

            foreach (var customStatus in newWorkflow.CustomStatuses)
            {
                createdWorkflow = await wrikeWorkflowsClient.UpdateAsync(
                    createdWorkflow.Id, customStatus: customStatus);
            }
            return createdWorkflow;
        }
    }
}

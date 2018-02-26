using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeWorkflowsClient
    {
        /// <summary>
        /// Returns list of workflows with custom statuses.
        /// Scopes: Default, wsReadOnly, wsReadWrite, amReadOnlyWorkflow, amReadWriteWorkflow
        /// </summary>
        /// p<param name="accountId">AccountId</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-workflows"/>
        Task<List<WrikeWorkflow>> GetAsync(string accountId);

        /// <summary>
        ///  Create workflow in account. Adds 2 default custom statuses Active & Completed
        ///  Scopes: amReadWriteWorkflow
        /// </summary>
        /// <param name="accountId">AccountId</param>
        /// <param name="newWorkflow">New workflow object with only name set, use constructor</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-workflow"/>
        Task<WrikeWorkflow> CreateAsync(string accountId, WrikeWorkflow newWorkflow);


        /// <summary>
        /// Update workflow or custom statuses
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-workflow"/>
        Task<WrikeWorkflow> UpdateAsync(string workflowId,
            string name = null, bool? isHidden = null, WrikeCustomStatus customStatus = null);
    }
}


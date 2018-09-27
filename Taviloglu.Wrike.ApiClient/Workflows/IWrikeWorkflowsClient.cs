using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Workflows;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Workflow operations
    /// </summary>
    public interface IWrikeWorkflowsClient
    {
        /// <summary>
        /// Returns list of workflows with custom statuses. 
        /// Scopes: Default, amReadOnlyWorkflow, amReadWriteWorkflow, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-workflows"/>
        Task<List<WrikeWorkflow>> GetAsync();

        /// <summary>
        ///  Create workflow in account.
        ///  Scopes: amReadWriteWorkflow
        /// </summary>
        /// <param name="newWorkflow">Use ctor <see cref="WrikeWorkflow.WrikeWorkflow(string)"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-workflow"/>
        Task<WrikeWorkflow> CreateAsync(WrikeWorkflow newWorkflow);

        /// <summary>
        /// Update workflow or custom statuses
        /// Scopes: amReadWriteWorkflow
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-workflow"/>
        Task<WrikeWorkflow> UpdateAsync(WrikeClientIdParameter id,
            string name = null, bool? isHidden = null, WrikeCustomStatus customStatus = null);
    }
}


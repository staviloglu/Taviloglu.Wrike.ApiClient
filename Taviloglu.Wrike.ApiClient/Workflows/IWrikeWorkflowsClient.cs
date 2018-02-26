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
        ///  Create workflow in account.
        ///  Scopes: amReadWriteWorkflow
        /// </summary>
        /// <param name="accountId">AccountId</param>
        /// <param name="name">Name of workflow</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-workflow"/>
        Task<WrikeWorkflow> CreateAsync(string accountId, string name);
    }
}

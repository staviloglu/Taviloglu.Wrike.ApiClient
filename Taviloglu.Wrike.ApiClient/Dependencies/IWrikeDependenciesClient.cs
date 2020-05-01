using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Dependencies;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Dependency operations
    /// </summary>
    public interface IWrikeDependenciesClient
    {

        /// <summary>
        /// Get task dependencies.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="taskId">Task ID</param>  
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-dependencies"/>
        Task<List<WrikeDependency>> GetInTaskAsync(WrikeClientIdParameter taskId);

        /// <summary>
        /// Returns complete information about single or multiple dependencies.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="ids">Dependency Ids</param>  
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-dependencies"/>
        Task<List<WrikeDependency>> GetAsync(WrikeClientIdListParameter ids);

        /// <summary>
        /// Add dependency between tasks.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="newDependency"></param>  
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-dependency"/>
        Task<WrikeDependency> CreateAsync(WrikeDependency newDependency);


        /// <summary>
        /// Change relationType of task dependency.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">Dependency Id</param>  
        /// <param name="relationType">Relation between Predecessor and Successor</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-dependency"/>
        Task<WrikeDependency> UpdateAsync(WrikeClientIdParameter id, WrikeDependencyRelationType relationType);



        /// <summary>
        /// Delete dependency between tasks.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">Dependency Id</param>  
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-dependency"/>
        Task DeleteAsync(WrikeClientIdParameter id);


    }
}

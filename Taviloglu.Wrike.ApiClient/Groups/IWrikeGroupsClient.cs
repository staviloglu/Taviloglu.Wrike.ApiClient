using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Groups;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Group operations
    /// </summary>
    public interface IWrikeGroupsClient
    {
        /// <summary>
        /// Delete group by Id
        /// Scopes: amReadWriteGroup
        /// </summary>
        /// <param name="id">Group Id</param>  
        /// <param name="isTest">Check that group can be removed</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-groups"/>
        Task DeleteAsync(WrikeClientIdParameter id, bool isTest = false);

        /// <summary>
        /// Returns complete information about single group.
        /// Scopes: amReadOnlyGroup, amReadWriteGroup
        /// </summary>
        /// <param name="id">Group Id</param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeGroup.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-groups"/>
        Task<WrikeGroup> GetAsync(WrikeClientIdParameter id, List<string> optionalFields = null);

        /// <summary>
        /// Returns all groups in the account.
        /// Scopes: amReadOnlyGroup, amReadWriteGroup
        /// </summary>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeGroup.OptionalFields"/></param>
        /// <param name="metaDataFilter">Metadata filter, exact match for metadata key or key-value pair</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-groups"/>
        Task<List<WrikeGroup>> GetAsync(List<string> optionalFields = null, WrikeMetadata metaDataFilter = null);

        /// <summary>
        /// Create group in account.
        /// Scopes: amReadWriteGroup
        /// </summary>
        /// <param name="newGroup"></param>
        /// <param name="parentId">Parent group ID</param>
        /// <param name="avatar">Info for group avatar creation</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-groups"/>
        Task<WrikeGroup> CreateAsync(WrikeGroup newGroup, string parentId = null, WrikeGroupAvatar avatar = null);

        /// <summary>
        ///  Update group by id.
        /// Scopes: amReadWriteGroup  
        /// <param name="id">Group Id</param>
        /// <param name="title">Title of group</param>
        /// <param name="membersToAdd">Add specified users to group</param>
        /// <param name="membersToRemove">Remove specified users from group</param>
        /// <param name="parentId">Parent group</param>
        /// <param name="avatar">Info for group avatar creation</param>
        /// <param name="metaData">Metadata to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-groups"/>
        /// </summary>
        Task<WrikeGroup> UpdateAsync(WrikeClientIdParameter id, string title = null, List<string> membersToAdd = null, List<string> membersToRemove = null, string parentId = null, WrikeGroupAvatar avatar = null, List<WrikeMetadata> metaData = null);
    }
}

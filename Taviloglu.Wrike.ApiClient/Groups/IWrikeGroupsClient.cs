using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeGroupsClient
    {
        /// <summary>
        /// Delete group by Id
        /// Scopes: amReadWriteGroup
        /// </summary>
        /// <param name="groupId"></param>  
        /// <param name="isTest">Check that group can be removed</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-groups"/>
        Task DeleteAsync(string groupId, bool isTest = false);


        /// <summary>
        /// Query Groups
        /// Scopes: amReadOnlyGroup, amReadWriteGroup
        /// </summary>
        /// <param name="groupId">If null, returns all groups in the account. If set returns complete information about single group.</param>
        /// <param name="optionalFields">Optional fields to be included in the response model 
        /// Use <see cref="WrikeGroup.OptionalFields"/></param>
        /// <param name="metaDataFilter">Metadata filter, exact match for metadata key or key-value pair</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-groups"/>
        Task<List<WrikeGroup>> GetAsync(string groupId=null, List<string> optionalFields = null, WrikeMetadata metaDataFilter = null);

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
        /// Modify Groups
        /// Scopes: amReadWriteGroup        
        /// <param name="title">Title of group</param>
        /// <param name="membersToAdd">Add specified users to group</param>
        /// <param name="membersToRemove">Remove specified users from group</param>
        /// <param name="parentId">Parent group</param>
        /// <param name="avatar">Info for group avatar creation</param>
        /// <param name="metaData">Metadata to be updated</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-groups"/>
        /// </summary>
        Task<WrikeGroup> UpdateAsync(string groupId, string title = null, List<string> membersToAdd = null, List<string> membersToRemove = null, string parentId = null, WrikeGroupAvatar avatar = null, List<WrikeMetadata> metaData = null);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeFoldersAndProjectsClient
    {
        /// <summary>
        /// Returns complete information about specified folders
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="folderIds">MaxCount 100</param>
        /// <param name="optionalFields">Use WrikeFolder.OptionalFields values</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-folder"/>
        Task<List<WrikeFolder>> GetFoldersAsync(List<string> folderIds, List<string> optionalFields = null);

        /// <summary>
        /// Returns a list of tree entries
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        ///<param name="accountId">Returns a list of tree entries for the account</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-folder-tree"/>
        Task<List<WrikeFolderTree>> GetFolderTreeAsync(
            string accountId = null, 
            string folderId = null,
            string permalink = null,
            bool? addDescendants = null,
            WrikeMetadata metadata = null,
            WrikeCustomFieldData customField = null,
            WrikeDateFilterRange updatedDate = null,
            bool? isProject = null,
            bool? isDeleted = null,
            List<string> fields = null);
    }
}

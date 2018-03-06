using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// <param name="optionalFields">Use <see cref="WrikeFolder.OptionalFields"/></param>
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


        /// <summary>
        ///  Create a folder within a folder. Specify virtual rootFolderId in order to create a folder in the account root
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="newFolder">Use ctor <see cref="WrikeFolder.WrikeFolder(string, string, List{string}, List{WrikeMetadata}, List{WrikeCustomFieldData}, List{string}, WrikeProject)"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-folder"/>
        Task<WrikeFolder> CreateAsync(string folderId, WrikeFolder newFolder);
    }




}

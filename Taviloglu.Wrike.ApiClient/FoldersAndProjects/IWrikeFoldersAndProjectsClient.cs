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


        /// <summary>
        /// Move folder and all descendant folders and tasks to Recycle Bin unless they have parents outside of deletion scope
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-folder"/>        
        Task<WrikeFolder> DeleteAsync(string folderId);






        /// <summary>
        /// Update folder.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="folderId">folderId</param>
        /// <param name="title">Title, cannot be empty</param>
        /// <param name="description">Folder description</param>
        /// <param name="addParents">Parent folders from same account to add, cannot contain rootFolderId and recycleBinId</param>
        /// <param name="removeParents">Parent folders from same account to remove, cannot contain rootFolderId and recycleBinId</param>
        /// <param name="addShareds">Share folder with specified users</param>
        /// <param name="removeShareds">Unshare folder from specified users</param>
        /// <param name="metadata">Metadata to be updated</param>
        /// <param name="restore">Restore folder from Recycled Bin</param>
        /// <param name="customFields">Custom fields to be updated or deleted (null value removes field)</param>
        /// <param name="customColumns">List of custom fields associated with folder</param>
        /// <param name="project">Project settings (update project or convert folder to project). Use null value to convert project to folder</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-folder"/> 
        Task<WrikeFolder> UpdateAsync(string folderId, string title, string description = null, List<string> addParents = null, List<string> removeParents = null, List<string> addShareds = null, List<string> removeShareds = null, List<WrikeMetadata> metadata = null, bool? restore = null, List<WrikeCustomFieldData> customFields = null, List<string> customColumns = null, WrikeProject project = null);
    }




}

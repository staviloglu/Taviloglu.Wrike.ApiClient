using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.FoldersAndProjects;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.FoldersAndProjects;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Folder &amp; Project operations
    /// </summary>
    public interface IWrikeFoldersAndProjectsClient
    {
        /// <summary>
        /// Returns complete information about specified folders
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="folderIds">MaxCount 100</param>
        /// <param name="optionalFields">Use <see cref="WrikeFolder.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-folder"/>
        Task<List<WrikeFolder>> GetFoldersAsync(WrikeClientIdListParameter folderIds, List<string> optionalFields = null);

        /// <summary>
        /// Returns a list of tree entries
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="folderId">Returns a list of tree entries for subtree of this folder. For root and recycle bin folders, returns folder subtrees of root and recycle bin respectively.</param>
        /// <param name="permalink">Folder permalink, exact match</param>
        /// <param name="addDescendants">Adds all descendant folders to search scope</param>
        /// <param name="metadata">Folders metadata filter</param> 
        /// <param name="customField">Custom field filter</param>
        /// <param name="updatedDate">Updated date filter, range</param>
        /// <param name="isProject">Get only projects (true) / only folders (false)</param>
        /// <param name="isDeleted">Get folders from Root (false) / Recycle Bin (true)</param>
        /// <param name="optionalFields">optional fields to be included in the response model. Use <see cref="WrikeFolderTree.OptionalFields"/></param> 
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-folder-tree"/>
        Task<List<WrikeFolderTree>> GetFolderTreeAsync(
            string folderId = null,
            string permalink = null,
            bool? addDescendants = null,
            WrikeMetadata metadata = null,
            WrikeCustomFieldData customField = null,
            WrikeDateFilterRange updatedDate = null,
            bool? isProject = null,
            bool? isDeleted = null,
            List<string> optionalFields = null);

        /// <summary>
        ///  Create a folder within a folder. Specify virtual rootFolderId in order to create a folder in the account root
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="newFolder">Use ctor <see cref="WrikeFolder.WrikeFolder(string, string, List{string}, List{WrikeMetadata}, List{WrikeCustomFieldData}, List{string}, WrikeProject)"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-folder"/>
        Task<WrikeFolder> CreateAsync(WrikeClientIdParameter folderId, WrikeFolder newFolder);
        

        /// <summary>
        /// Copy folder subtree, returns parent folder subtree.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="folderId">Folder Id to be copied</param>
        /// <param name="parentFolderId">ID of parent folder (copy to folder Id)</param>
        /// <param name="title">Title</param>
        /// <param name="titlePrefix">Title prefix for all copied tasks</param>
        /// <param name="copyDescriptions">Copy descriptions or leave empty</param>
        /// <param name="copyResponsibles">Copy responsibles</param>
        /// <param name="addResponsibles">Add specified users to task responsible list</param>
        /// <param name="removeResponsibles">Remove specified users from task responsible list</param>
        /// <param name="copyCustomFields">Copy custom fields</param>
        /// <param name="copyCustomStatuses">Copy custom statuses or set according to workflow otherwise</param>
        /// <param name="copyStatuses">Copy task statuses or set to Active otherwise</param>
        /// <param name="copyParents">Preserve parent folders</param>
        /// <param name="rescheduleDate">Date to use in task rescheduling. Note that only active tasks can be rescheduled. To activate and reschedule all tasks, use 'rescheduleDate' in combination with copyStatuses = false</param>
        /// <param name="rescheduleMode">Mode to be used for rescheduling (based on first or last date), has effect only if reschedule date is specified. </param>
        /// <param name="entryLimit">Limit maximum allowed number for tasks/folders in tree for copy, operation will fail if limit is exceeded, should be 1..250</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/copy-folder"/> 
        Task<WrikeFolder> CopyAsync(WrikeClientIdParameter folderId, WrikeClientIdParameter parentFolderId, string title, string titlePrefix = null, bool? copyDescriptions = null, bool? copyResponsibles = null, List<string> addResponsibles = null, List<string> removeResponsibles = null, bool copyCustomFields = true, bool copyCustomStatuses = true, bool copyStatuses = true, bool copyParents = false, DateTime? rescheduleDate = null, FolderRescheduleMode? rescheduleMode = FolderRescheduleMode.Start, int entryLimit = 250);

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
        Task<WrikeFolder> UpdateAsync(WrikeClientIdParameter folderId, string title, string description = null, List<string> addParents = null, List<string> removeParents = null, List<string> addShareds = null, List<string> removeShareds = null, List<WrikeMetadata> metadata = null, bool? restore = null, List<WrikeCustomFieldData> customFields = null, List<string> customColumns = null, WrikeProject project = null);

        /// <summary>
        /// Move folder and all descendant folders and tasks to Recycle Bin unless they have parents outside of deletion scope
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-folder"/>        
        Task<WrikeFolder> DeleteAsync(WrikeClientIdParameter folderId);
    }




}

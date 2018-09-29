using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Attachments;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Attachment operations
    /// </summary>
    public interface IWrikeAttachmentsClient
    {
        /// <summary>
        /// Return all Attachments of account tasks and folders. 
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="versions">Get attachments with previous versions.</param>
        /// <param name="createdDate">Created date filter. Required to request attachments in account. Time range duration should be less than 31 day.</param>
        /// <param name="withUrls">Get attachment URLs.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-attachments"/>
        Task<List<WrikeAttachment>> GetAsync(bool? versions = null, WrikeDateFilterRange createdDate = null, bool? withUrls = null);

        /// <summary>
        /// Returns all Attachments of a folder.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="folderId">Folder ID</param>
        /// <param name="versions">Get attachments with previous versions.</param>
        /// <param name="createdDate">Created date filter. Required to request attachments in account. Time range duration should be less than 31 day.</param>
        /// <param name="withUrls">Get attachment URLs.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-attachments"/>
        Task<List<WrikeFolderAttachment>> GetInFolderAsync(WrikeClientIdParameter folderId, bool? versions = null, WrikeDateFilterRange createdDate = null, bool? withUrls = null);

        /// <summary>
        /// Returns all Attachments of a task.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <param name="versions">Get attachments with previous versions.</param>
        /// <param name="createdDate">Created date filter. Required to request attachments in account. Time range duration should be less than 31 day.</param>
        /// <param name="withUrls">Get attachment URLs.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-attachments"/>
        Task<List<WrikeTaskAttachment>> GetInTaskAsync(WrikeClientIdParameter taskId, bool? versions = null, WrikeDateFilterRange createdDate = null, bool? withUrls = null);


        /// <summary>
        /// Returns complete information about single or multiple attachments.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="ids">Attachment ids</param>
        /// <param name="versions">Get attachments with previous versions.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-attachments"/>
        Task<List<WrikeAttachment>> GetAsync(WrikeClientIdListParameter ids, bool? versions = null);

        /// <summary>
        /// Returns attachment content. It can be accessed via /attachments/id/download/name.ext URL. In this case, 'name.ext' will be returned as the file name.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="id">Attachment ID</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/download-wrike-attachment"/>
        Task<System.IO.Stream> DownloadAsync(WrikeClientIdParameter id);

        /// <summary>
        /// Returns Preview for the attachment. The preview can be accessed via /attachments/id/preview/name.ext URL. In this case, 'name.ext' will be returned as the file name.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="id">Attachment ID.</param>
        /// <param name="size">Preview dimensions</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/download-attachment-preview"/>
        Task<System.IO.Stream> DownloadPreviewAsync(WrikeClientIdParameter id, WrikePreviewDimension? size = null);


        /// <summary>
        /// Public URL to attachment from Wrike or external service.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="id">Attachment ID</param>
        /// /// See <see href="https://developers.wrike.com/documentation/api/methods/get-access-url-for-attachment"/>
        Task<WrikeAttachmentUrl> GetAccessUrlAsync(WrikeClientIdParameter id);


        /// <summary>
        ///  Add an attachment to a task.
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="taskId">Task ID to add attachment</param>
        /// <param name="fileBytes">File bytes</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-wrike-attachment"/>
        Task<WrikeTaskAttachment> CreateInTaskAsync(WrikeClientIdParameter taskId, string fileName, byte[] fileBytes);


        /// <summary>
        ///  Add an attachment to a folder.
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="folderId">Folder ID to add attachment</param>
        /// <param name="fileBytes">File bytes</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-wrike-attachment"/>
        Task<WrikeFolderAttachment> CreateInFolderAsync(WrikeClientIdParameter folderId, string fileName, byte[] fileBytes);



        /// <summary>
        /// Delete Attachment by ID.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="id">Attachment ID</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-attachment"/>
        Task DeleteAsync(WrikeClientIdParameter id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeAttachmentsClient
    {

        /// <summary>
        /// Returns all Attachments of a account,task or folder.  
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="accountId">Search among all attachments in the account.</param>
        /// <param name="folderId">Search among all attachments in the folder.</param>
        /// <param name="taskId">Search among all attachments in the task.</param>
        /// <param name="versions">Get attachments with previous versions.</param>
        /// <param name="createdDate">Created date filter. Required to request attachments in account. Time range duration should be less than 31 day.</param>
        /// <param name="withUrls">Get attachment URLs.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-attachments"/>
        Task<List<WrikeAttachment>> GetAsync(string accountId=null, string folderId=null, string taskId=null,
            bool? versions = null,
            WrikeDateFilterRange createdDate = null,
            bool? withUrls = null);


        /// <summary>
        /// Returns complete information about an Attachment 
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="attachmentId">Search among all attachments in the task.</param>
        /// <param name="versions">Get attachments with previous versions.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-attachments"/>
        Task<WrikeAttachment> GetAsync(string attachmentId,
            bool? versions = null);

        /// <summary>
        /// Returns attachment content. It can be accessed via /attachments/id/download/name.ext URL. In this case, 'name.ext' will be returned as the file name.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="attachmentId">Search among all attachments in the task.</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/download-wrike-attachment"/>
        Task<System.IO.Stream> DownloadAsync(string attachmentId);

        /// <summary>
        /// Returns Preview for the attachment. The preview can be accessed via /attachments/id/preview/name.ext URL. In this case, 'name.ext' will be returned as the file name.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="attachmentId">Search among all attachments in the task.</param>
        /// <param name="size">Preview dimensions</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/download-attachment-preview"/>
        Task<System.IO.Stream> DownloadPreviewAsync(string attachmentId, WrikePreviewDimension? size);
    }
}

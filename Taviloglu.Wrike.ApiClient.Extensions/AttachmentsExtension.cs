using System.IO;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Attachments;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class AttachmentsExtension
    {
        /// <summary>
        /// Downloads the attachment and saves it to the given path
        /// </summary>
        /// <param name="wrikeAttachmentsClient"></param>
        /// <param name="attachmentId">Attachment ID</param>
        /// <param name="savingPath">Path to save file</param>
        public static async Task DownloadAndSaveAttachment(this IWrikeAttachmentsClient wrikeAttachmentsClient, WrikeClientIdParameter attachmentId, string savingPath)
        {
            using (var downloadedStream = await wrikeAttachmentsClient.DownloadAsync(attachmentId).ConfigureAwait(false))
            {                
                using (FileStream fs = new FileStream(savingPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    while ((len = downloadedStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, len);
                    }
                }
            }
        }


        /// <summary>
        /// Uploads the attachment to given task
        /// </summary>
        /// <param name="wrikeAttachmentsClient"></param>
        /// <param name="taskId">Task ID</param>
        /// <param name="filePath">Full path of the file</param>
        /// <param name="fileName">If not given gets the name from filePath</param>
        public static async Task<WrikeTaskAttachment> CreateAttachmentInTask(this IWrikeAttachmentsClient wrikeAttachmentsClient, WrikeClientIdParameter taskId, string filePath, string fileName = null)
        {
            var fileBytes = File.ReadAllBytes(filePath);

            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Path.GetFileName(filePath);
            }

            return await wrikeAttachmentsClient.CreateInTaskAsync(taskId, fileName, fileBytes).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads the attachment to given folder
        /// </summary>
        /// <param name="wrikeAttachmentsClient"></param>
        /// <param name="folderId">Folder ID</param>
        /// <param name="filePath">Full path of the file</param>
        /// <param name="fileName">If not given gets the name from filePath</param>
        public static async Task<WrikeFolderAttachment> CreateAttachmentInFolder(this IWrikeAttachmentsClient wrikeAttachmentsClient, WrikeClientIdParameter folderId, string filePath, string fileName = null)
        {
            var fileBytes = File.ReadAllBytes(filePath);

            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Path.GetFileName(filePath);
            }

            return await wrikeAttachmentsClient.CreateInFolderAsync(folderId, fileName, fileBytes).ConfigureAwait(false);
        }
    }
}

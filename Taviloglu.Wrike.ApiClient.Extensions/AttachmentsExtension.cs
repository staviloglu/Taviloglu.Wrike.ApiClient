using System.IO;
using System.Threading.Tasks;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class AttachmentsExtension
    {
        public static async Task DownloadAndSaveAttachment(this IWrikeAttachmentsClient wrikeAttachmentsClient, string attachmentId, string savingPath)
        {
            using (var downloadedStream = await wrikeAttachmentsClient.DownloadAsync(attachmentId))
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
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public class AttachmentsSamples
    {
        const string FolderId = "IEACGXLUI4IHJMYP";
        const string TaskId = "IEACGXLUKQIGFGAK";

        public static async Task Run(WrikeClient client)
        {

            var attachments = await client.Attachments.GetAsync();

            var preview = await client.Attachments.DownloadPreviewAsync(attachments[0].Id, Core.Attachments.WrikePreviewDimension.w44);

            var url = await client.Attachments.GetAccessUrlAsync(attachments[0].Id);

            var attachmentUrl = await client.Attachments.GetAccessUrlAsync(attachments[0].Id);



            attachments = await client.Attachments.GetAsync(new List<string> { attachments[0].Id });



            var wrikeLogoFileBytes = File.ReadAllBytes("wrikeLogo.png");
            
            //var createdTaskAttachment = 
            //    await client.Attachments.CreateInTask(TaskId, "wrikeLogo.png", wrikeLogoFileBytes)
            
            var createdFolderAttachment =
                await client.Attachments.CreateInFolderAsync(FolderId, "wrikeLogo.png", wrikeLogoFileBytes);




            var currentAccount = await client.Accounts.GetAsync();

            var tasks = await client.Tasks.GetAsync(fields: new List<string>() { WrikeTask.OptionalFields.HasAttachments, WrikeTask.OptionalFields.AttachmentCount });

            var tasksWithAttachments = tasks.Where(o => o.HasAttachments).ToList();

            foreach (var task in tasksWithAttachments)
            {
                var taskAttachments = await client.Attachments.GetInTaskAsync(task.Id, withUrls: true);

                foreach (var taskAttachment in taskAttachments)
                {
                    var stream = await client.Attachments.DownloadAsync(taskAttachment.Id);
                }
            }
        }
    }
}

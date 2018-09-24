using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public class AttachmentsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var currentAccount = await client.Accounts.GetAsync();

            var tasks = await client.Tasks.GetAsync(fields: new List<string>() { WrikeTask.OptionalFields.HasAttachments, WrikeTask.OptionalFields.Description });
            var tasksWithAttachments = tasks.Where(o => o.HasAttachments).ToList();
            foreach (var task in tasksWithAttachments)
            {
                var attachments = await client.Attachments.GetAsync(taskId: task.Id, withUrls: true);
                foreach (var attachment in attachments)
                {
                    var stream = await client.Attachments.DownloadAsync(attachment.Id);
                }
            }

        }
    }
}

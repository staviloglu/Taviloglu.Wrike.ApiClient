using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Extensions;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public class AttachmentsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var accounts = await client.Accounts.GetAsync();
            foreach (var account in accounts)
            {
                var tasks = await client.Tasks.GetAsync(accountId: account.Id, fields: new List<string>() { WrikeTask.OptionalFields.HasAttachments,WrikeTask.OptionalFields.Description });
                var tasksWithAttachments = tasks.Where(o=>o.HasAttachments).ToList();
                foreach(var task in tasksWithAttachments)
                {
                    var attachments = await client.Attachments.GetAsync(taskId: task.Id,withUrls:true);

                    foreach (var attachment in attachments)
                    {
                        var stream=await client.Attachments.GetAsync(attachment.Id);
                    }
                }
            }
          
        }
    }
}

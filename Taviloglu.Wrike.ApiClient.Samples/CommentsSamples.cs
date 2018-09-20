using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class CommentsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            var tasks = await client.Tasks.GetAsync();
            var specialTask = tasks.FirstOrDefault(t => t.Permalink.Contains("273185186"));

            var newComment = new WrikeComment("test comment #1", taskId: specialTask.Id);
            var comments = await client.Comments.GetAsync();

            newComment = await client.Comments.CreateAsync(newComment, true);
            var updatedComment = await client.Comments.UpdateAsync(newComment.Id, "updated comment #1", true);
            comments = await client.Comments.GetAsync(new List<string> { newComment.Id });
            await client.Comments.DeleteAsync(newComment.Id);
        }
    }
}

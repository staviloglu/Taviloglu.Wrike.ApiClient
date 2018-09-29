using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class TasksExtensions
    {
        /// <summary>
        /// Provides a method to get task with single taskId rather than List
        /// </summary>
        public static async Task<WrikeTask> GetTaskByIdAsync(this IWrikeTasksClient wrikeTasksClient, WrikeClientIdParameter taskId)
        {
            var tasks = await wrikeTasksClient.GetAsync(taskIds: new List<string> { taskId }).ConfigureAwait(false);
            return tasks.FirstOrDefault();
        }

        /// <summary>
        /// Provides a method to get a tasks subTasks without the need to call get function for the superTask
        /// </summary>
        public static async Task<List<WrikeTask>> GetSubTasksBySuperTaskIdAsync(this IWrikeTasksClient wrikeTasksClient, WrikeClientIdParameter superTaskId)
        {
            var superTask = await GetTaskByIdAsync(wrikeTasksClient, superTaskId).ConfigureAwait(false);            

            if (superTask.SubTaskIds.Count == 0)
            {
                return new List<WrikeTask>();
            }

            return await wrikeTasksClient.GetAsync(taskIds: superTask.SubTaskIds).ConfigureAwait(false);
        }
    }
}

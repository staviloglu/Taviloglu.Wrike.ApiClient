using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Extensions
{
    public static class TasksExtensions
    {
        public static async Task<WrikeTask> GetTaskByIdAsync(this IWrikeTasksClient wrikeTasksClient, string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            var tasks = await wrikeTasksClient.GetAsync(taskIds: new List<string> { taskId});
            return tasks.FirstOrDefault();
        }


        public static async Task<List<WrikeTask>> GetSubTasksBySuperTaskIdAsync(this IWrikeTasksClient wrikeTasksClient, string superTaskId)
        {
            if (string.IsNullOrWhiteSpace(superTaskId))
            {
                throw new ArgumentNullException(nameof(superTaskId));
            }

            var superTask = await GetTaskByIdAsync(wrikeTasksClient, superTaskId);

            if (superTask == null)
            {
                return new List<WrikeTask>();
            }

            return await wrikeTasksClient.GetAsync(taskIds: superTask.SubTaskIds);            
        }
    }
}

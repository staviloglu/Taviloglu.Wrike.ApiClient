using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class TasksSamples
    {
        public static async Task Run(WrikeClient client)
        {
            //many other optional parameters
            var tasks = await client.Tasks.GetAsync(
                createdDate: new WrikeDateFilterRange(new DateTime(2018, 1, 1), new DateTime(2018, 2, 5)),
                sortOrder: WrikeSortOrder.Asc,
                sortField: WrikeTaskSortField.CreatedDate,
                scheduledDate: new WrikeDateFilterRange(new DateTime(2018, 1, 1), new DateTime(2018, 2, 5)),
                dueDate: new WrikeDateFilterEqual(new DateTime(2018, 2, 5)),
                limit: 10
                );

            tasks = await client.Tasks.GetAsync(accountId: "accountId");

            tasks = await client.Tasks.GetAsync(folderId: "folderId");

            tasks = await client.Tasks.GetAsync(new List<string> { "taskId", "taskId" });

            tasks = await client.Tasks.GetAsync(
                new List<string> { "taskId", "taskId" },
                new List<string> {
                    WrikeTask.OptionalFields.AttachmentCount,
                    WrikeTask.OptionalFields.Recurrent }
                );

            tasks = await client.Tasks.GetAsync();

            var newTask = new WrikeTask
            {
                Title = "new task title",
                Description = "new task description",
                Status = WrikeTaskStatus.Active,
                Importance = WrikeTaskImportance.High,
                Dates = new WrikeTaskDate
                {
                    Due = new DateTime(2018, 2, 20),
                    Duration = 180000,
                    Start = DateTime.Now,
                    Type = WrikeTaskDateType.Planned,
                    WorkOnWeekends = false

                },
                SharedIds = null,
                ParentIds = null,
                ResponsibleIds = null,
                FollowerIds = null,
                FollowedByMe = false,
                SuperTaskIds = null,
                Metadata = new List<WrikeMetadata> {
                    new WrikeMetadata("metadata1","metadata1.value")
                },
                CustomStatusId = null
            };
            newTask = await client.Tasks.CreateAsync("folderId", newTask);

            tasks = await client.Tasks.GetAsync();

            newTask = await client.Tasks.UpdateAsync(
                newTask.Id,
                title: "updated task title",
                description: "updated description");

            var deletedTask = await client.Tasks.DeleteAsync(newTask.Id);

            tasks = await client.Tasks.GetAsync();
        }
    }
}

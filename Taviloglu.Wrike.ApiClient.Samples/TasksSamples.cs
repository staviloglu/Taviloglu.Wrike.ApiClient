using System;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class TasksSamples
    {
        public static async Task Run(WrikeClient client)
        {

            var tasks = await client.Tasks.GetAsync();

            var dueDate = DateTime.Now.AddDays(1);
            var newTask = new WrikeTask($"Due Date Should Be {dueDate.ToString("yyyy-MM-dd")}", dates: new WrikeTaskDate { Due = dueDate });
            newTask = await client.Tasks.CreateAsync("IEACGXLUI4IEQ6NG", newTask);



            //many other optional parameters
            //var tasks = await client.Tasks.GetAsync(
            //    createdDate: new WrikeDateFilterRange(new DateTime(2018, 1, 1), new DateTime(2018, 2, 5)),
            //    sortOrder: WrikeSortOrder.Asc,
            //    sortField: WrikeTaskSortField.CreatedDate,
            //    scheduledDate: new WrikeDateFilterRange(new DateTime(2018, 1, 1), new DateTime(2018, 2, 5)),
            //    dueDate: new WrikeDateFilterEqual(new DateTime(2018, 2, 5)),
            //    limit: 10
            //    );

            //tasks = await client.Tasks.GetAsync(accountId: "accountId");

            //tasks = await client.Tasks.GetAsync(folderId: "folderId");

            //tasks = await client.Tasks.GetAsync(new List<string> { "taskId", "taskId" });

            //tasks = await client.Tasks.GetAsync(
            //    new List<string> { "taskId", "taskId" },
            //    new List<string> {
            //        WrikeTask.OptionalFields.AttachmentCount,
            //        WrikeTask.OptionalFields.Recurrent }
            //    );

            //var tasks = await client.Tasks.GetAsync();


            //paged example       
            var pagedTaskList = await client.Tasks.GetAsync(pageSize: 20);
            //you can read this property only after first paged request, otherwise it is 0
            var responseSize = client.Tasks.LastResponseSize; 
            //if you keep requesting with LastNextPageToken it will be empty when you get your last tasks of paged response
            var nextPageToken = client.Tasks.LastNextPageToken; 
            while (!string.IsNullOrWhiteSpace(nextPageToken))
            {
                pagedTaskList = await client.Tasks.GetAsync(nextPageToken: nextPageToken);
                nextPageToken = client.Tasks.LastNextPageToken;
                //client.Tasks.LastResponseSize is zero here
            }

            //another paged example
            do
            {
              var pagedList2 = await client.Tasks.GetAsync(nextPageToken:client.Tasks.LastNextPageToken, pageSize:20);
            } while (!string.IsNullOrWhiteSpace(client.Tasks.LastNextPageToken));


            //var newTask = new WrikeTask
            //{
            //    Title = "new task title",
            //    Description = "new task description",
            //    Status = WrikeTaskStatus.Active,
            //    Importance = WrikeTaskImportance.High,
            //    Dates = new WrikeTaskDate
            //    {
            //        Due = DateTime.Now.AddDays(5),
            //        Duration = 180000,
            //        Start = DateTime.Now,
            //        Type = WrikeTaskDateType.Planned,
            //        WorkOnWeekends = false

            //    },
            //    SharedIds = null,
            //    ParentIds = null,
            //    ResponsibleIds = null,
            //    FollowerIds = null,
            //    FollowedByMe = false,
            //    SuperTaskIds = null,
            //    Metadata = new List<WrikeMetadata> {
            //        new WrikeMetadata("metadata1","metadata1.value")
            //    },
            //    CustomStatusId = null
            //};
            //newTask = await client.Tasks.CreateAsync("folderId", newTask);

            //tasks = await client.Tasks.GetAsync();

            //newTask = await client.Tasks.UpdateAsync(
            //    newTask.Id,
            //    title: "updated task title",
            //    description: "updated description");

            //var deletedTask = await client.Tasks.DeleteAsync(newTask.Id);

            //tasks = await client.Tasks.GetAsync();
        }
    }
}

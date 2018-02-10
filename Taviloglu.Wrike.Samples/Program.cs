using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var bearerToken = "your_berarer_token";
            var wrikeClient = new WrikeClient(bearerToken);

            #region Colors
            //var colors = await wrikeClient.Colors.GetAsync();
            #endregion

            #region CustomFields
            //var customFields = await wrikeClient.CustomFields.GetAsync();
            //var customFields = await wrikeClient.CustomFields.GetAsync (new List<string> { "IEABX2HEJUAAREOB", "IEABX2HEJUAAREOD" });

            //TODO: returns invalid-parameter error if type is not Text
            //var updatedCustomField = await wrikeClient.CustomFields.UpdateAsync(
            //    "IEABX2HEJUAATMXD",
            //    title: "sinanTestField3",
            //    type: WrikeCustomFieldType.Money);


            //var newCustomField = new WrikeCustomField
            //{
            //    AccountId = "IEABX2HE",
            //    Title = "Sinan Test Custom Duration",
            //    Type = WrikeCustomFieldType.Duration
            //};
            //var field = await wrikeClient.CustomFields.CreateAsync(newCustomField);
            #endregion

            #region Tasks
            //many other optional parameters
            //var tasks0 = await wrikeClient.Tasks.GetAsync(
            //    createdDate: new WrikeDateFilterRange(
            //        new DateTime(2018, 1, 1), new DateTime(2018, 2, 5)),
            //    sortOrder: WrikeSortOrder.Asc,
            //    sortField: WrikeTaskSortField.CreatedDate,
            //    scheduledDate: new WrikeDateFilterRange(
            //        new DateTime(2018, 1, 1), new DateTime(2018, 2, 5)),
            //    dueDate: new WrikeDateFilterEqual(new DateTime(2018, 2, 5)),
            //    limit: 10);
            //var tasks1 = await wrikeClient.Tasks.GetAsync(accountId: "IEABX2HE");
            //var tasks2 = await wrikeClient.Tasks.GetAsync(folderId: "");
            //var tasks3 = await wrikeClient.Tasks.GetAsync(new List<string> { "IEABX2HEKQGIKBTE", "IEABX2HEKQGIKBYK" });
            //var tasks4 = await wrikeClient.Tasks.GetAsync(new List<string> { "IEABX2HEKQGIKBTE", "IEABX2HEKQGIKBYK" },
            //new List<string> { WrikeTask.OptionalFields.AttachmentCount, WrikeTask.OptionalFields.Recurrent });


            //var newTask = new WrikeTask
            //{
            //    Title = "new task title",
            //    Description = "new task description",
            //    Status = WrikeTaskStatus.Active,
            //    Importance = WrikeTaskImportance.High,
            //    Dates = new WrikeTaskDate
            //    {
            //        Due = new DateTime(2018, 2, 20),
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
            //var taskReturn = await wrikeClient.Tasks.CreateAsync("IEABX2HEI4FR342D", newTask);

            //var deletedTask = await wrikeClient.Tasks.DeleteAsync(taskReturn.Data.First().Id);
            #endregion

            #region Users
            //var user = await wrikeClient.Users.GetAsync("");
            #endregion

            #region Version
            //var version = await wrikeClient.Version.GetAsync();            
            #endregion

            #region Folders
            //var folders = await wrikeClient.FoldersAndProjects.GetFolderTreeAsync("IEABX2HE");
            //var folders = await wrikeClient.FoldersAndProjects.GetFoldersAsync(
            //    new List<string> { "IEABX2HEI4FR342D", "IEABR5PBI4EW24CW" },
            //    new List<string> { WrikeFolder.OptionalFields.AttachmentCount,
            //        WrikeFolder.OptionalFields.BriefDescription,
            //        WrikeFolder.OptionalFields.CustomColumnIds});

            //var folders = await wrikeClient.FoldersAndProjects.GetFoldersAsync(
            //new List<string> { "IEABX2HEI4FR342D", "IEABR5PBI4EW24CW" });
            #endregion

            #region Groups
            //var g = wrikeClient.Groups.DeleteAsync("", true);
            //var g = wrikeClient.Groups.DeleteAsync("");            
            #endregion
        }
    }
}

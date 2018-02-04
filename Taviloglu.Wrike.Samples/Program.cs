using System.Collections.Generic;
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
            var bearerToken = "WQIheQFM74FvIqZ5caumDvog1nrmNbgz8ehjGiJn9NSz3M7rR8rSir8bnib23M8T-N-WFIUKC";
            var wrikeClient = new WrikeClient(bearerToken);

            #region Colors
            //var colors = await wrikeClient.GetColorsAsync();
            #endregion

            #region CustomFields
            //var customFields = await wrikeClient.GetCustomFieldsAsync();
            //var customFields = await wrikeClient.GetCustomFiledInfoAsync(new List<string> { "IEABX2HEJUAAREOB", "IEABX2HEJUAAREOD" });

            //TODO: returns invalid-parameter error if type is not Text
            //var updatedCustomField = await wrikeClient.UpdateCustomFieldAsync(
            //    "IEABX2HEJUAATMXD", 
            //    title: "sinanTestField3",
            //    type: WrikeCustomFieldType.Money);


            //var newCustomField = new WrikeCustomField
            //{
            //    AccountId = "IEABX2HE",
            //    Title = "Sinan Test Custom Duration",
            //    Type = WrikeCustomFieldType.Duration
            //};
            //var field = await wrikeClient.CreateCustomFieldAsync(newCustomField);
            #endregion

            #region Tasks
            var tasks = await wrikeClient.GetTasksAsync(new List<string> { "IEABX2HEKQGIKBTE", "IEABX2HEKQGIKBYK" });

            tasks = await wrikeClient.GetTasksAsync(new List<string> { "IEABX2HEKQGIKBTE", "IEABX2HEKQGIKBYK" },
                new List<string> { WrikeTask.OptionalFields.AttachmentCount, WrikeTask.OptionalFields.Recurrent });
            #endregion

            #region Users
            //var user = await wrikeClient.GetUserAsync("");
            #endregion

            #region Version
            //var version = await wrikeClient.GetVersion();
            #endregion

            #region Folders
            //var folders = await wrikeClient.GetFolderTreeAsync("IEABX2HE");
            //var folders = await wrikeClient.GetFoldersAsync(
            //    new List<string> { "IEABX2HEI4FR342D", "IEABR5PBI4EW24CW" },
            //    new List<string> { WrikeFolder.OptionalFields.AttachmentCount,
            //        WrikeFolder.OptionalFields.BriefDescription,
            //        WrikeFolder.OptionalFields.CustomColumnIds});

            //folders = await wrikeClient.GetFoldersAsync(
            //    new List<string> { "IEABX2HEI4FR342D", "IEABR5PBI4EW24CW" });
            #endregion
        }
    }
}

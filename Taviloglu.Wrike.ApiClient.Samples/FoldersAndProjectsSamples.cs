using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class FoldersAndProjectsSamples
    {
        public static async Task Run(WrikeClient client)
        {
            //try other options...
            //var folderTrees = await client.FoldersAndProjects.GetFolderTreeAsync("IEABX2HE");

            //var folders = await client.FoldersAndProjects.GetFoldersAsync(
            //    new List<string> { "folderId", "folderId" },
            //    new List<string> {
            //        WrikeFolder.OptionalFields.AttachmentCount,
            //        WrikeFolder.OptionalFields.BriefDescription,
            //        WrikeFolder.OptionalFields.CustomColumnIds}
            //    );

            //folders = await client.FoldersAndProjects.GetFoldersAsync(
            //new List<string> { "folderId", "folderId" }
            //);
            

            var rootFolderId = "root-folderId";

            var newFolder = new WrikeFolder("Sinan Test Folder2", 
                description: "Test Folder for development of wrike integration");

            newFolder = await client.FoldersAndProjects.CreateAsync(rootFolderId,newFolder);
            newFolder = await client.FoldersAndProjects.UpdateAsync(newFolder.Id, "Sinan Test Folder #2", addShareds: new List<string> { "newIdToAdd" });
            await client.FoldersAndProjects.DeleteAsync(newFolder.Id);


            
        }
    }
}

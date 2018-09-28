using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.FoldersAndProjects;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class FoldersAndProjectsSamples
    {
        const string TestFolderId = "IEACGXLUI4IHJMYP";

        static readonly List<string> DefaultFolderIds = new List<string> { "IEACGXLUI7777777", "IEACGXLUI7777776", "IEACGXLUI4IEQ6NG", "IEACGXLUI4IEQ6NH", "IEACGXLUI4IEQ6NB", TestFolderId };

        public static async Task Run(WrikeClient client)
        {
            //try other options...
            var folderTrees = await client.FoldersAndProjects.GetFolderTreeAsync();

            var folders = await client.FoldersAndProjects.GetFoldersAsync(DefaultFolderIds);


            //var copiedFolder = await client.FoldersAndProjects.CopyAsync("IEACGXLUI4IEQ6NB", "IEACGXLUI4IHJMYP","CopiedFolder");

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

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
            var folderTrees = await client.FoldersAndProjects.GetFolderTreeAsync("accountId");

            var folders = await client.FoldersAndProjects.GetFoldersAsync(
                new List<string> { "folderId", "folderId" },
                new List<string> {
                    WrikeFolder.OptionalFields.AttachmentCount,
                    WrikeFolder.OptionalFields.BriefDescription,
                    WrikeFolder.OptionalFields.CustomColumnIds}
                );

            folders = await client.FoldersAndProjects.GetFoldersAsync(
            new List<string> { "folderId", "folderId" }
            );
        }
    }
}

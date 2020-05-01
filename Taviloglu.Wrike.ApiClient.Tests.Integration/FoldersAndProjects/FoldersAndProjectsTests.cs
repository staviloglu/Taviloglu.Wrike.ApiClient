using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.FoldersAndProjects;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.FoldersAndProjects
{
    [TestFixture, Order(8)]
    public class FoldersAndProjectsTests
    {
        const string RootFolderId = "IEACGXLUI7777777";
        const string RecycleBinFolderId = "IEACGXLUI7777776";
        const string PersonalFolderId = "IEACGXLUI4KZG6UV";

        readonly List<string> DefaultFolderIds = new List<string> { RootFolderId, RecycleBinFolderId, PersonalFolderId };

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var folderTree = WrikeClientFactory.GetWrikeClient().FoldersAndProjects.GetFolderTreeAsync().Result;

            var folderTreeOfRecycleBin = WrikeClientFactory.GetWrikeClient().FoldersAndProjects.GetFolderTreeAsync(RecycleBinFolderId).Result;

            foreach (var folder in folderTree)
            {
                if (!DefaultFolderIds.Contains(folder.Id) && !folderTreeOfRecycleBin.Any(f=> f.Id == folder.Id))
                {
                    WrikeClientFactory.GetWrikeClient().FoldersAndProjects.DeleteAsync(folder.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetFolderTreeAsync_ShouldReturnFolderTrees()
        {
            var folderTrees = WrikeClientFactory.GetWrikeClient().FoldersAndProjects.GetFolderTreeAsync().Result;
            Assert.IsNotNull(folderTrees);
            Assert.GreaterOrEqual(folderTrees.Count, 3);
        }

        [Test, Order(2)]
        public void GetFoldersAsync_ShouldReturnPersonalFolder()
        {
            var folders = WrikeClientFactory.GetWrikeClient().FoldersAndProjects.GetFoldersAsync(DefaultFolderIds).Result;
            Assert.IsNotNull(folders);
            Assert.AreEqual(1, folders.Count);
            Assert.AreEqual(PersonalFolderId, folders[0].Id);
        }

        [Test, Order(3)]
        public void CreateAsync_ShouldAddNewFolderWithTitle()
        {
            var newFolder = new WrikeFolder("TestFolder #1");

            var createdFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects.CreateAsync(RootFolderId, newFolder).Result;            

            Assert.IsNotNull(createdFolder);
            Assert.AreEqual(newFolder.Title, createdFolder.Title);

            //TODO: test other parameters
        }


        [Test, Order(4)]
        public void CopyAsync_ShouldCopyFolder()
        {
            var parentFolder = new WrikeFolder("My Parent Folder");
            parentFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects
                .CreateAsync(RootFolderId, parentFolder).Result;

            var folderToBeCopied = new WrikeFolder("My Folder To Be Copied");
            folderToBeCopied = WrikeClientFactory.GetWrikeClient().FoldersAndProjects
                .CreateAsync(RootFolderId, folderToBeCopied).Result;

            var expectedTitle = "Copied";
            var copiedFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects
                .CopyAsync(folderToBeCopied.Id, parentFolder.Id, "Copied").Result;

            Assert.IsNotNull(copiedFolder);
            Assert.AreEqual(expectedTitle, copiedFolder.Title);
            Assert.IsNotNull(copiedFolder.ParentIds);
            Assert.AreEqual(parentFolder.Id, copiedFolder.ParentIds.First());
        }

        [Test, Order(5)]
        public void UpdateAsync_ShouldUpdateFolderTitle()
        {
            var newFolder = new WrikeFolder("My Folder #1");
            newFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects
                .CreateAsync(RootFolderId, newFolder).Result;

            var expectedTitle = "My Folder #1 [Updated]";
            var updatedFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects
                .UpdateAsync(newFolder.Id, expectedTitle).Result;

            Assert.IsNotNull(updatedFolder);
            Assert.AreEqual(expectedTitle, updatedFolder.Title);

            //TODO: test other parameters
        }

        [Test, Order(6)]
        public void DeleteAsync_ShouldDeleteNewFolder()
        {
            var newFolder = new WrikeFolder("My Folder #2");
            newFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects
                .CreateAsync(RootFolderId, newFolder).Result;

            var deletedFolder = WrikeClientFactory.GetWrikeClient().FoldersAndProjects.DeleteAsync(newFolder.Id).Result;

            Assert.IsNotNull(deletedFolder);
        }
    }
}

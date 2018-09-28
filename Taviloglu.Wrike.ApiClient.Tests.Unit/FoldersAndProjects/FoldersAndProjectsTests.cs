using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.FoldersAndProjects;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.FoldersAndProjects
{
    [TestFixture]
    public class FoldersAndProjectsTests
    {
        [Test]
        public void FoldersAndProjectsProperty_ShouldReturnFoldersAndProjectsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeFoldersAndProjectsClient), TestConstants.WrikeClient.FoldersAndProjects);
        }

        [Test]
        public void UpdateAsync_WhenTitleEmpty_ThrowArgumentException()
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(() => TestConstants.WrikeClient.FoldersAndProjects.UpdateAsync("folderId", string.Empty));
            Assert.AreEqual("title", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void UpdateAsync_WhenTitleNull_ThrowArgumentNullException()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.FoldersAndProjects.UpdateAsync("folderId", null));
            Assert.AreEqual("title", ex.ParamName);
        }



        [Test]
        public void GetFoldersAsync_WhenOptionalFieldsNotInRange_ThrowArgumentOutOfRangeException()
        {
            var optionalFields = new List<string> { "wrongOptionalField", WrikeFolder.OptionalFields.CustomColumnIds };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.FoldersAndProjects.GetFoldersAsync(new List<string> { "folderID"}, optionalFields: optionalFields));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeFolder.OptionalFields"));
        }

        [Test]
        public void GetFolderTreeAsync_WhenOptionalFieldsNotInRange_ThrowArgumentOutOfRangeException()
        {
            var optionalFields = new List<string> { "wrongOptionalField", WrikeFolder.OptionalFields.CustomColumnIds };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.FoldersAndProjects.GetFolderTreeAsync(optionalFields: optionalFields));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeFolderTree.OptionalFields"));
        }
    }
}

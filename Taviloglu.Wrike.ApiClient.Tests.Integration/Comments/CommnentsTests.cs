using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Comments;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Comments
{
    [TestFixture]
    public class CommnentsTests
    {
        const string DefaultCommentId = "IEACGXLUIMHLQB2D";
        const string DefaultTaskId = "IEACGXLUKQIEQ6NC";
        const string DefaultFolderId = "IEACGXLUI4IEQ6NG";

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetAsync().Result;

            foreach (var comment in comments)
            {
                if (comment.Id != DefaultCommentId)
                {
                    WrikeClientFactory.GetWrikeClient().Comments.DeleteAsync(comment.Id).Wait();
                }
            }
        }

        [Test]
        public void GetAsync_ShouldReturnComments()
        {
            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetAsync().Result;
            Assert.IsNotNull(comments);
            Assert.Greater(comments.Count, 0);            
        }

        [Test]
        public void GetInTaskAsync_ShouldReturnComments()
        {
            var newComment = new WrikeTaskComment("My new test comment", DefaultTaskId);
            var createdComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetInTaskAsync(DefaultTaskId).Result;

            Assert.IsNotNull(comments);
            Assert.Greater(comments.Count, 0);
            Assert.IsTrue(comments.Any(c => c.Id == createdComment.Id));
        }

        [Test]
        public void GetInFolderAsync_ShouldReturnComments()
        {
            var newComment = new WrikeFolderComment("My new test comment", DefaultFolderId);
            var createdComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetInFolderAsync(DefaultFolderId).Result;

            Assert.IsNotNull(comments);
            Assert.Greater(comments.Count, 0);
            Assert.IsTrue(comments.Any(c => c.Id == createdComment.Id));
        }

        [Test]
        public void GetAsyncWithIds_ShouldReturnDefaultComment()
        {
            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetAsync(new List<string> { DefaultCommentId }).Result;
            Assert.IsNotNull(comments);
            Assert.AreEqual(1, comments.Count);
            Assert.AreEqual(DefaultCommentId, comments.First().Id);
        }

        [Test]
        public void CreateAsync_ShouldAddNewNewCommentToDefaultTask()
        {            
            var newComment = new WrikeTaskComment("My new test comment", DefaultTaskId);

            var createdComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            Assert.IsNotNull(createdComment);
            Assert.AreEqual(newComment.Text, createdComment.Text);
            Assert.AreEqual(newComment.TaskId, createdComment.TaskId);
        }

        [Test]
        public void CreateAsync_ShouldAddNewNewCommentToDefaultFolder()
        {
            var newComment = new WrikeFolderComment("My new test comment", DefaultFolderId);

            var createdComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            Assert.IsNotNull(createdComment);
            Assert.AreEqual(newComment.Text, createdComment.Text);
            Assert.AreEqual(newComment.FolderId, createdComment.FolderId);
        }

        [Test]
        public void UpdateAsync_ShouldUpdateCommentText()
        {
            var newComment = new WrikeTaskComment("My new test comment", DefaultTaskId);

            newComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            var expectedCommentText = "My new test comment [Updated]";
            var updatedComment = WrikeClientFactory.GetWrikeClient().Comments.UpdateAsync(newComment.Id, expectedCommentText, plainText: true).Result;

            Assert.IsNotNull(updatedComment);
            Assert.AreEqual(expectedCommentText, updatedComment.Text);
        }

        [Test]
        public void DeleteAsync_ShouldDeleteComment()
        {
            var newComment = new WrikeTaskComment("My new test comment", DefaultTaskId);
            newComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            WrikeClientFactory.GetWrikeClient().Comments.DeleteAsync(newComment.Id).Wait();

            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetAsync().Result;
            var isCommentDeleted = !comments.Any(c => c.Id == newComment.Id);

            Assert.IsTrue(isCommentDeleted);
        }
    }
}

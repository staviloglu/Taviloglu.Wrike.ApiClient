using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Comments
{
    [TestFixture]
    public class CommnentsTests
    {
        const string DefaultCommentId = "IEACGXLUIMHLQB2D";
        const string DefaultTaskId = "IEACGXLUKQIEQ6NC";
        const string DefaultFolderId = "IEACGXLUI4IEQ6NG";

        [OneTimeTearDown]
        public void SetToDefaults()
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
        public void GetAsync_ShouldReturnDefaultComment()
        {
            SetToDefaults();

            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetAsync().Result;
            Assert.IsNotNull(comments);
            Assert.AreEqual(1, comments.Count);
            Assert.AreEqual(DefaultCommentId, comments.First().Id);
        }

        [Test]
        public void CreateAsync_ShouldAddNewNewCommentToDefaultTask()
        {            
            var newComment = new WrikeComment("My new test comment", taskId: DefaultTaskId);

            var createdComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            var commentsOfTask = WrikeClientFactory.GetWrikeClient().Comments.GetAsync(taskId: DefaultTaskId).Result;


            Assert.IsNotNull(newComment);
            Assert.AreEqual(newComment.Text, createdComment.Text);
            Assert.IsNotNull(commentsOfTask);
            Assert.IsNotEmpty(commentsOfTask);
            Assert.AreEqual(createdComment.Text, commentsOfTask.First().Text);
        }

        [Test]
        public void CreateAsync_ShouldAddNewNewCommentToDefaultFolder()
        {
            var newComment = new WrikeComment("My new test comment", folderId: DefaultFolderId);

            var createdComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            var commentsOfFolder = WrikeClientFactory.GetWrikeClient().Comments.GetAsync(folderId: DefaultFolderId).Result;

            Assert.IsNotNull(newComment);
            Assert.AreEqual(newComment.Text, createdComment.Text);
            Assert.IsNotNull(commentsOfFolder);
            Assert.IsNotEmpty(commentsOfFolder);
            Assert.AreEqual(createdComment.Text, commentsOfFolder.First().Text);
        }

        [Test]
        public void UpdateAsync_ShouldUpdateCommentText()
        {
            var newComment = new WrikeComment("My new test comment", taskId: DefaultTaskId);
            newComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;
            var expectedCommentText = "My new test comment [Updated]";
            var updatedComment = WrikeClientFactory.GetWrikeClient().Comments.UpdateAsync(newComment.Id, expectedCommentText, plainText: true).Result;

            Assert.IsNotNull(updatedComment);
            Assert.AreEqual(expectedCommentText, updatedComment.Text);
        }

        [Test]
        public void DeleteAsync_ShouldDeleteComment()
        {
            var newComment = new WrikeComment("My new test comment", taskId: DefaultTaskId);
            newComment = WrikeClientFactory.GetWrikeClient().Comments.CreateAsync(newComment, plainText: true).Result;

            WrikeClientFactory.GetWrikeClient().Comments.DeleteAsync(newComment.Id);

            var comments = WrikeClientFactory.GetWrikeClient().Comments.GetAsync().Result;
            var isCommentDeleted = !comments.Any(c => c.Id == newComment.Id);

            Assert.IsTrue(isCommentDeleted);
        }
    }
}

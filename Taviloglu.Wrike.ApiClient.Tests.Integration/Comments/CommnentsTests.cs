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
        WrikeClient _wrikeClient;

        const string DefaultCommentId = "IEACGXLUIMHLQB2D";
        const string DefaultTaskId = "IEACGXLUKQIEQ6NC";
        const string DefaultFolderId = "IEACGXLUI4IEQ6NG";

        [OneTimeSetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [OneTimeTearDown]
        public void RestoreCommentsToDefault()
        {
            var comments = _wrikeClient.Comments.GetAsync().Result;

            foreach (var comment in comments)
            {
                if (comment.Id != DefaultCommentId)
                {
                    _wrikeClient.Comments.DeleteAsync(comment.Id).Wait();
                }
            }
        }

        [Test]
        public void GetAsync_ShouldReturnDefaultComment()
        {
            RestoreCommentsToDefault();

            var comments = _wrikeClient.Comments.GetAsync().Result;
            Assert.IsNotNull(comments);
            Assert.AreEqual(1, comments.Count);
            Assert.AreEqual(DefaultCommentId, comments.First().Id);
        }

        [Test]
        public void CreateAsync_ShouldAddNewNewCommentToDefaultTask()
        {            
            var newComment = new WrikeComment("My new test comment", taskId: DefaultTaskId);

            var createdComment = _wrikeClient.Comments.CreateAsync(newComment, plainText: true).Result;

            var commentsOfTask = _wrikeClient.Comments.GetAsync(taskId: DefaultTaskId).Result;


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

            var createdComment = _wrikeClient.Comments.CreateAsync(newComment, plainText: true).Result;

            var commentsOfFolder = _wrikeClient.Comments.GetAsync(folderId: DefaultFolderId).Result;

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
            newComment = _wrikeClient.Comments.CreateAsync(newComment, plainText: true).Result;
            var expectedCommentText = "My new test comment [Updated]";
            var updatedComment = _wrikeClient.Comments.UpdateAsync(newComment.Id, expectedCommentText, plainText: true).Result;

            Assert.IsNotNull(updatedComment);
            Assert.AreEqual(expectedCommentText, updatedComment.Text);
        }

        [Test]
        public void DeleteAsync_ShouldDeleteComment()
        {
            var newComment = new WrikeComment("My new test comment", taskId: DefaultTaskId);
            newComment = _wrikeClient.Comments.CreateAsync(newComment, plainText: true).Result;

            _wrikeClient.Comments.DeleteAsync(newComment.Id);

            var comments = _wrikeClient.Comments.GetAsync().Result;
            var isCommentDeleted = !comments.Any(c => c.Id == newComment.Id);

            Assert.IsTrue(isCommentDeleted);
        }
    }
}

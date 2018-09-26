using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Comments;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Comments
{
    [TestFixture]
    public class CommentsTests
    {
        [Test]
        public void CommentsProperty_ShouldReturnCommentsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeCommentsClient), TestConstants.WrikeClient.Comments);
        }

        [Test]
        public void CreateAsync_WhenCommentNull_ThrowArgumentNullException()
        {
            WrikeFolderComment newComment = null;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(()=>TestConstants.WrikeClient.Comments.CreateAsync(newComment));
            Assert.AreEqual("newComment", ex.ParamName);
        }

        [Test]
        public void UpdateAsync_WhenTextEmpty_ThrowArgumentException()
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(() => TestConstants.WrikeClient.Comments.UpdateAsync("commentId", string.Empty));
            Assert.AreEqual("text", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void UpdateAsync_WhenTextNull_ThrowArgumentNullException()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Comments.UpdateAsync("commentId", null));
            Assert.AreEqual("text", ex.ParamName);
        }
    }
}

using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Comments;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeTaskCommentTests
    {
        [Test]
        public void Ctor_WhenTextEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeTaskComment(string.Empty,"folderId"));
            Assert.AreEqual("text", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenTextNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeTaskComment(null,"folderId"));
            Assert.AreEqual("text", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenFolderIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeTaskComment("text", string.Empty));
            Assert.AreEqual("taskId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenFolderIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeTaskComment("text", null));
            Assert.AreEqual("taskId", ex.ParamName);
        }
    }
}

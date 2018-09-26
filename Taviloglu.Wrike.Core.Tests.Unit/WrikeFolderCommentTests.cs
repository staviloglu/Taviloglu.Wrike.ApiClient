using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Comments;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeFolderCommentTests
    {
        [Test]
        public void Ctor_WhenTextEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeFolderComment(string.Empty,"folderId"));
            Assert.AreEqual("text", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenTextNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeFolderComment(null,"folderId"));
            Assert.AreEqual("text", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenFolderIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeFolderComment("text", string.Empty));
            Assert.AreEqual("folderId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenFolderIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeFolderComment("text", null));
            Assert.AreEqual("folderId", ex.ParamName);
        }
    }
}

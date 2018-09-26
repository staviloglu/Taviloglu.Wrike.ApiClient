using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Groups;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeGroupAvatarTests
    {
        [Test]
        public void Ctor_WhenLettersEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(()=> new WrikeGroupAvatar("colorName", string.Empty));
            Assert.AreEqual("letters", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenLettersNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeGroupAvatar("colorName", null));
            Assert.AreEqual("letters", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenLettersMoreThanTwoCharacters_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeGroupAvatar("colorName", "GNNNN"));
            Assert.AreEqual("letters", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("letters can be 2 characters max."));
        }

        [Test]
        public void Ctor_WhenColorEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeGroupAvatar(string.Empty, "GN"));
            Assert.AreEqual("color", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenColorsNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeGroupAvatar(null, "GN"));
            Assert.AreEqual("color", ex.ParamName);
        }

        
    }
}

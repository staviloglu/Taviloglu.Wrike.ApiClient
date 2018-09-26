using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Colors;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeColorTests
    {
        [Test]
        public void Ctor_WhenHexEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(()=> new WrikeColor("colorName", string.Empty));
            Assert.AreEqual("hex", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenNameEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeColor(string.Empty, "hex"));
            Assert.AreEqual("name", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenNameNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeColor(null, "hex"));
            Assert.AreEqual("name", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenHexNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeColor("colorName", null));
            Assert.AreEqual("hex", ex.ParamName);
        }
    }
}

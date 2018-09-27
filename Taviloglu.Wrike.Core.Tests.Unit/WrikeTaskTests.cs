using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Groups;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeTaskTests
    {
        [Test]
        public void Ctor_WhenTitleEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeGroup(string.Empty));
            Assert.AreEqual("title", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenTitleNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeGroup(null));
            Assert.AreEqual("title", ex.ParamName);
        }
    }
}

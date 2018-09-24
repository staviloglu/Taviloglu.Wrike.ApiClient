using NUnit.Framework;
using System;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeGroupTests
    {
        [Test]
        public void Ctor_WhenTitleEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeGroup(string.Empty));
            Assert.AreEqual("title", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be emtpy"));
        }


        [Test]
        public void Ctor_WhenTitleNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeGroup(null));
            Assert.AreEqual("title", ex.ParamName);
        }
    }
}

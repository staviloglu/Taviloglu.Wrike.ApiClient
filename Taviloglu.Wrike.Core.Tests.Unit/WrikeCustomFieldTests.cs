using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.CustomFields;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeCustomFieldTests
    {
        [Test]
        public void Ctor_WhenTitleEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeCustomField(string.Empty, WrikeCustomFieldType.Text));
            Assert.AreEqual("title", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenTitleNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeCustomField(null, WrikeCustomFieldType.Text));
            Assert.AreEqual("title", ex.ParamName);
        }
    }
}

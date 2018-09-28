using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.CustomFields;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeCustomFieldDataTests
    {
        [Test]
        public void Ctor_WhenValueEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeCustomFieldData("customFieldId", string.Empty));
            Assert.AreEqual("value", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenValueNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeCustomFieldData("customFieldId",null));
            Assert.AreEqual("value", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenCustomFieldIdEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeCustomFieldData(string.Empty,"value"));
            Assert.AreEqual("customFieldId", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenCustomFieldIdNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeCustomFieldData(null,"value"));
            Assert.AreEqual("customFieldId", ex.ParamName);
        }
    }
}

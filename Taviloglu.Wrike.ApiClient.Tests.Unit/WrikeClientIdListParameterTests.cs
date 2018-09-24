using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit
{
    [TestFixture]
    public class WrikeClientIdListParameterTests
    {
        [Test]
        public void Ctor_WhenIdListNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeClientIdListParameter(null));
            Assert.AreEqual("idList", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenIdListEmpty_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeClientIdListParameter(new List<string>()));
            Assert.AreEqual("idList", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }

        [Test]
        public void Ctor_WhenIdListHasMoreThanHundredItems_ThrowsArgumentException()
        {
            //101 items list
            var testItems = new List<string>();
            for (int i = 0; i < 101; i++) { testItems.Add("id"); }

            var ex = Assert.Throws<ArgumentException>(() => new WrikeClientIdListParameter(testItems));
            Assert.AreEqual("idList", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can contain 100 items max."));
        }
    }
}

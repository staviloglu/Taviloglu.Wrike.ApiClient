using NUnit.Framework;
using System;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit
{
    [TestFixture]
    public class WrikeClientTests
    {
        [Test]
        public void Ctor_WhenHostNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeClient("bearerToken",null));
            Assert.AreEqual("host", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenBearerTokenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeClient(null));
            Assert.AreEqual("bearerToken", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenHostEmptyString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeClient("bearerToken", string.Empty));
            Assert.AreEqual("host", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be emtpy"));
        }

        [Test]
        public void Ctor_WhenBearerTokenEmptyString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeClient(string.Empty));
            Assert.AreEqual("bearerToken", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be emtpy"));
        }
    }
}

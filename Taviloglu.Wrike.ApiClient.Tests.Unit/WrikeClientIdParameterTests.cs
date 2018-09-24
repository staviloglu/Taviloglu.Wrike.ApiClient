using NUnit.Framework;
using System;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit
{
    [TestFixture]
    public class WrikeClientIdParameterTests
    {
        [Test]
        public void Ctor_WhenIdNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeClientIdParameter(null));
            Assert.AreEqual("id", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenIdEmptyString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeClientIdParameter(string.Empty));
            Assert.AreEqual("id", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }
    }
}

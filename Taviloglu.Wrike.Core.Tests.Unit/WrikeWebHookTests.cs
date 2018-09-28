using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Groups;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.Core.Tests.Unit
{
    [TestFixture]
    public class WrikeWebHookTests
    {
        [Test]
        public void Ctor_WhenHookUrlEmpty_ThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WrikeWebHook(string.Empty));
            Assert.AreEqual("hookUrl", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }


        [Test]
        public void Ctor_WhenHookUrlNull_ThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WrikeWebHook(null));
            Assert.AreEqual("hookUrl", ex.ParamName);
        }

        [Test]
        public void Ctor_WhenHookUrlIsNotHttps_ThrowArgumentException()
        {   
            var ex = Assert.Throws<ArgumentException>(() => new WrikeWebHook("http://"));
            Assert.AreEqual("hookUrl", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("hookUrl should be https"));
        }
    }
}

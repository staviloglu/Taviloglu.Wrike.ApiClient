using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.WebHooks
{
    [TestFixture]
    public class WebHooksTests
    {
        [Test]
        public void WebHooksProperty_ShouldReturnWebHooksClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeWebHooksClient), TestConstants.WrikeClient.WebHooks);
        }

        [Test]
        public void CreateAsync_NewWebHookNull_ThrowArgumentNullException()
        {
            WrikeWebHook newWebHook = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.WebHooks.CreateAsync("folderId",newWebHook));
            Assert.AreEqual("newWebHook", ex.ParamName);
        }
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.WebHooks
{
    [TestFixture, Order(17)]
    public class WebHooksTests
    {
        const string DefaultWebHookId = "IEACGXLUJAAACP54";
        const string TestFolderId = "IEACGXLUI4IHJMYP";

        //Thanks to @fredsted
        //https://github.com/fredsted/webhook.site
        //https://webhook.site/#/ca5bbc32-9f4c-433c-a8d4-be18041def50/3e31dc6c-0a28-457e-b292-600f39e392c8/0
        const string TestWebHookAddress = "https://webhook.site/ca5bbc32-9f4c-433c-a8d4-be18041def50";


        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var webHooks = WrikeClientFactory.GetWrikeClient().WebHooks.GetAsync().Result;

            foreach (var webHook in webHooks)
            {
                if (webHook.Id != DefaultWebHookId)
                {
                    WrikeClientFactory.GetWrikeClient().WebHooks.DeleteAsync(webHook.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnWebHooks()
        {
            var webhooks = WrikeClientFactory.GetWrikeClient().WebHooks.GetAsync().Result;
            Assert.IsNotNull(webhooks);
        }

        [Test, Order(2)]
        public void GetAsync_ShouldReturnDefaultDefaultWebHook()
        {
            var webHookIds = new List<string> { DefaultWebHookId };

            var webHooks = WrikeClientFactory.GetWrikeClient().WebHooks.GetAsync(webHookIds).Result;
            Assert.IsNotNull(webHooks);
            Assert.AreEqual(1, webHooks.Count);
            Assert.AreEqual(DefaultWebHookId, webHooks.First().Id);
        }

        [Test, Order(3)]
        public void CreateAsync_ShouldAddNewwebHookWithUrlToFolder()
        {
            var newWebHook = new WrikeWebHook(TestWebHookAddress, TestFolderId);

            var createdWebHook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebHook).Result;

            Assert.IsNotNull(createdWebHook);
            Assert.AreEqual(newWebHook.HookUrl, createdWebHook.HookUrl);
            Assert.AreEqual(newWebHook.Status, createdWebHook.Status);
            Assert.AreEqual(newWebHook.FolderId, createdWebHook.FolderId);
        }

        [Test, Order(4)]
        public void CreateAsync_ShouldAddNewwebHookWithUrlToAccount()
        {
            var newWebHook = new WrikeWebHook(TestWebHookAddress);

            var createdWebHook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebHook).Result;

            Assert.IsNotNull(createdWebHook);
            Assert.AreEqual(newWebHook.HookUrl, createdWebHook.HookUrl);
            Assert.AreEqual(newWebHook.Status, createdWebHook.Status);
        }

        [Test, Order(5)]
        public void UpdateAsync_ShouldUpdateWebHookStatus()
        {
            var newWebHook = new WrikeWebHook(TestWebHookAddress, TestFolderId);
            newWebHook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebHook).Result;

            var expectedStatus = WrikeWebHookStatus.Suspended;
            var updatedWebHook = WrikeClientFactory.GetWrikeClient().WebHooks.UpdateAsync(newWebHook.Id, expectedStatus).Result;

            Assert.IsNotNull(updatedWebHook);
            Assert.AreEqual(expectedStatus, updatedWebHook.Status);
        }

        [Test, Order(6)]
        public void DeleteAsync_ShouldDeleteNewGroup()
        {
            var newWebHook = new WrikeWebHook(TestWebHookAddress, TestFolderId);
            newWebHook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebHook).Result;

            WrikeClientFactory.GetWrikeClient().WebHooks.DeleteAsync(newWebHook.Id).Wait();

            var webHooks = WrikeClientFactory.GetWrikeClient().Groups.GetAsync().Result;
            var isWebHookDeleted = !webHooks.Any(wh => wh.Id == newWebHook.Id);

            Assert.IsTrue(isWebHookDeleted);
        }
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.WebHooks;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Webhooks
{
    [TestFixture, Order(17)]
    public class WebhooksTests
    {
        const string DefaultWebhookId = "IEACGXLUJAAACP54";
        const string PersonalFolderId = "IEACGXLUI4KZG6UV";

        //Thanks to @fredsted
        //https://github.com/fredsted/Webhook.site
        const string TestWebhookAddress = "https://Webhook.site/#!/71de1b3b-cc83-48a5-8c82-69ec10a1bc1e";


        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var Webhooks = WrikeClientFactory.GetWrikeClient().WebHooks.GetAsync().Result;

            foreach (var Webhook in Webhooks)
            {
                if (Webhook.Id != DefaultWebhookId)
                {
                    WrikeClientFactory.GetWrikeClient().WebHooks.DeleteAsync(Webhook.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnWebhooks()
        {
            var Webhooks = WrikeClientFactory.GetWrikeClient().WebHooks.GetAsync().Result;
            Assert.IsNotNull(Webhooks);
        }

        [Test, Order(2)]
        public void GetAsync_ShouldReturnDefaultDefaultWebhook()
        {
            var WebhookIds = new List<string> { DefaultWebhookId };

            var Webhooks = WrikeClientFactory.GetWrikeClient().WebHooks.GetAsync(WebhookIds).Result;
            Assert.IsNotNull(Webhooks);
            Assert.AreEqual(1, Webhooks.Count);
            Assert.AreEqual(DefaultWebhookId, Webhooks.First().Id);
        }

        [Test, Order(3)]
        public void CreateAsync_ShouldAddNewWebhookWithUrlToFolder()
        {
            var newWebhook = new WrikeWebHook(TestWebhookAddress, PersonalFolderId);

            var createdWebhook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebhook).Result;

            Assert.IsNotNull(createdWebhook);
            Assert.AreEqual(newWebhook.HookUrl, createdWebhook.HookUrl);
            Assert.AreEqual(newWebhook.Status, createdWebhook.Status);
            Assert.AreEqual(newWebhook.FolderId, createdWebhook.FolderId);
        }

        [Test, Order(4)]
        public void CreateAsync_ShouldAddNewWebhookWithUrlToAccount()
        {
            var newWebhook = new WrikeWebHook(TestWebhookAddress);

            var createdWebhook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebhook).Result;

            Assert.IsNotNull(createdWebhook);
            Assert.AreEqual(newWebhook.HookUrl, createdWebhook.HookUrl);
            Assert.AreEqual(newWebhook.Status, createdWebhook.Status);
        }

        [Test, Order(5)]
        public void UpdateAsync_ShouldUpdateWebhookStatus()
        {
            var newWebhook = new WrikeWebHook(TestWebhookAddress, PersonalFolderId);
            newWebhook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebhook).Result;

            var expectedStatus = WrikeWebHookStatus.Suspended;
            var updatedWebhook = WrikeClientFactory.GetWrikeClient().WebHooks.UpdateAsync(newWebhook.Id, expectedStatus).Result;

            Assert.IsNotNull(updatedWebhook);
            Assert.AreEqual(expectedStatus, updatedWebhook.Status);
        }

        [Test, Order(6)]
        public void DeleteAsync_ShouldDeleteNewGroup()
        {
            var newWebhook = new WrikeWebHook(TestWebhookAddress, PersonalFolderId);
            newWebhook = WrikeClientFactory.GetWrikeClient().WebHooks.CreateAsync(newWebhook).Result;

            WrikeClientFactory.GetWrikeClient().WebHooks.DeleteAsync(newWebhook.Id).Wait();

            var Webhooks = WrikeClientFactory.GetWrikeClient().Groups.GetAsync().Result;
            var isWebhookDeleted = !Webhooks.Any(wh => wh.Id == newWebhook.Id);

            Assert.IsTrue(isWebhookDeleted);
        }
    }
}

using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Webhooks
{
    [TestFixture]
    public class WebhooksTests
    {
        [Test]
        public void WebhooksProperty_ShouldReturnWebhooksClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeWebHooksClient), TestConstants.WrikeClient.WebHooks);
        }
    }
}

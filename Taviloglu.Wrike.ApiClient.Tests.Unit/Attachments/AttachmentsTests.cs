using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Attachments
{
    [TestFixture]
    public class AttachmentsTests
    {
        [Test]
        public void AttachmentsProperty_ShouldReturnAttachmentsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeAttachmentsClient), TestConstants.WrikeClient.Attachments);
        }
    }
}

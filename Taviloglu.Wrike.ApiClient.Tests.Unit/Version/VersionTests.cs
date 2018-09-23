using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Version
{
    [TestFixture]
    public class VersionTests
    {
        [Test]
        public void VersionProperty_ShouldReturnVersionClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeVersionClient), TestConstants.WrikeClient.Version);
        }
    }
}

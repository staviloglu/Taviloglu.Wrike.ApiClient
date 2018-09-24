using NUnit.Framework;
using Taviloglu.Wrike.Core.Version;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Version
{
    [TestFixture]
    public class VersionTests
    {
        [Test]
        public void GetAsync_ShouldRetunMajor1Minor0()
        {
            var expectedWrikeVersion = new WrikeVersion
            {
                Major = "1",
                Minor = "0"
            };

            var actualWrikeVersion = WrikeClientFactory.GetWrikeClient().Version.GetAsync().Result;

            Assert.AreEqual(expectedWrikeVersion.Major, actualWrikeVersion.Major);
            Assert.AreEqual(expectedWrikeVersion.Minor, actualWrikeVersion.Minor);
        }
    }
}

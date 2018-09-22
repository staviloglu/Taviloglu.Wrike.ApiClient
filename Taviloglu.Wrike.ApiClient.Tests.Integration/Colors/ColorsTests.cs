using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Colors
{
    [TestFixture]
    public class ColorsTests
    {
        [Test]
        public void GetAsync_ShouldRetun64Colors()
        {
            var expectedColorCount = 64;

            var actualColorCount = WrikeClientFactory.GetWrikeClient().Colors.GetAsync().Result.Count;

            Assert.AreEqual(expectedColorCount, actualColorCount);
        }
    }
}

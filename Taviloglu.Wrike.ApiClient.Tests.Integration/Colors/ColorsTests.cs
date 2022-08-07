using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Colors
{
    [TestFixture, Order(3)]
    public class ColorsTests
    {
        const int ColorCount = 86;

        [Test]
        public void GetAsync_ShouldRetun86Colors()
        {
            var actualColorCount = WrikeClientFactory.GetWrikeClient().Colors.GetAsync().Result.Count;

            Assert.AreEqual(ColorCount, actualColorCount);
        }
    }
}

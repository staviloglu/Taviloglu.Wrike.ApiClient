using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.TimelogCategories
{
    [TestFixture, Order(13)]
    public class TimelogCategoriesTests
    {
        [Test]
        public void GetAsync_ShouldReturnTimelogCategories()
        {
            var timelogCategories = WrikeClientFactory.GetWrikeClient().TimeLogCategories.GetAsync();
            Assert.IsNotNull(timelogCategories);
        }
    }
}

using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.TimelogCategories
{
    [TestFixture]
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

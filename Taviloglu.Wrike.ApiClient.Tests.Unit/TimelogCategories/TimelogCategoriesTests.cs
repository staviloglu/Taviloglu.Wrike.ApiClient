using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.TimelogCategories
{
    [TestFixture]
    public class TimelogCategoriesTests
    {

        [Test]
        public void TimelogCategoriesProperty_ShouldReturnTimelogCategoriesClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeTimelogsClient), TestConstants.WrikeClient.TimeLogCategories);
        }
    }
}

using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Timelogs
{
    [TestFixture]
    public class TimelogsTests
    {
        [Test]
        public void TimelogsProperty_ShouldReturnTimelogsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeTimelogsClient), TestConstants.WrikeClient.Timelogs);
        }
    }
}

using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Timelogs;

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

        [Test]
        public void CreateAsync_NewTimelogNull_ThrowArgumentNullException()
        {
            WrikeTimelog newTimelog = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Timelogs.CreateAsync(newTimelog));
            Assert.AreEqual("newTimelog", ex.ParamName);
        }
    }
}

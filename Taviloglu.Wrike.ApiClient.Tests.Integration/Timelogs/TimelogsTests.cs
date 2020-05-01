using NUnit.Framework;
using System;
using System.Linq;
using Taviloglu.Wrike.Core.Timelogs;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Timelogs
{
    [TestFixture, Order(14)]
    public class TimelogsTests
    {
        const string DefaultTimelogId = "IEACGXLUJQAH4GLQ";
        const string DefaultTaskId = "IEACGXLUKQO6DCNW";

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var timelogs = WrikeClientFactory.GetWrikeClient().Timelogs.GetAsync().Result;

            foreach (var timelog in timelogs)
            {
                if (timelog.Id != DefaultTimelogId)
                {
                    WrikeClientFactory.GetWrikeClient().Timelogs.DeleteAsync(timelog.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnTimelogs()
        {
            var timelogs = WrikeClientFactory.GetWrikeClient().Timelogs.GetAsync().Result;
            Assert.IsNotNull(timelogs);
            Assert.GreaterOrEqual(timelogs.Count, 1);
        }

        [Test, Order(2)]
        public void GetAsync_WithUpdatedDateFilter_ShouldReturnTimelogs()
        {
            var updatedDateFilter = new Core.WrikeDateFilterRange(new DateTime(2000, 1, 1), DateTime.UtcNow);
            var timelogs = WrikeClientFactory.GetWrikeClient().Timelogs.GetAsync(updatedDate: updatedDateFilter).Result;

            Assert.IsNotNull(timelogs);
            Assert.NotZero(timelogs.Count);
            foreach (var timelog in timelogs)
            {
                Assert.IsTrue(updatedDateFilter.Start <= timelog.UpdatedDate && timelog.UpdatedDate < updatedDateFilter.End);
            }
        }

        // TODO: test other get options fiwth taskId, contactId, folderId, timelogCategoryId

        [Test, Order(3)]
        public void CreateAsync_ShouldAddNewTimelogWithComment()
        {
            var newTimelog = new WrikeTimelog(DefaultTaskId , 1m, DateTime.Now, comment: "test timelog #2");
            var createdTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            Assert.IsNotNull(newTimelog);
            Assert.AreEqual(newTimelog.Comment, createdTimelog.Comment);

            //TODO: test other parameters
        }

        [Test, Order(4)]
        public void CreateAsync_ShouldAddNewTimelogWithoutComment()
        {
            var newTimelog = new WrikeTimelog(DefaultTaskId , 1m, DateTime.Now);
            var createdTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            Assert.IsNotNull(newTimelog);

            //TODO: test other parameters
        }

        [Test, Order(5)]
        public void UpdateAsync_ShouldUpdateTimelogComment()
        {
            var newTimelog = new WrikeTimelog(DefaultTaskId , 1m, DateTime.Now, comment: "test timelog #2");
            newTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            var expectedComment = "test timelog #2 [Updated]";
            var updatedTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.UpdateAsync(newTimelog.Id, expectedComment).Result;

            Assert.IsNotNull(updatedTimelog);
            Assert.AreEqual(expectedComment, updatedTimelog.Comment);

            //TODO: test other parameters
        }

        [Test, Order(6)]
        public void DeleteAsync_ShouldDeleteNewTimelog()
        {
            var newTimelog = new WrikeTimelog(DefaultTaskId , 1m, DateTime.Now);
            var createdTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            WrikeClientFactory.GetWrikeClient().Timelogs.DeleteAsync(createdTimelog.Id).Wait();

            var timelogs = WrikeClientFactory.GetWrikeClient().Timelogs.GetAsync().Result;
            var isTimelogDeleted = !timelogs.Any(t => t.Id == createdTimelog.Id);

            Assert.IsTrue(isTimelogDeleted);
        }

    }
}

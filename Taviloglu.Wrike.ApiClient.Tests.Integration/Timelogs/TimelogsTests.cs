using NUnit.Framework;
using System;
using System.Linq;
using Taviloglu.Wrike.Core.Timelogs;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Timelogs
{
    [TestFixture]
    public class TimelogsTests
    {
        const string DefaultTimelogId = "IEACGXLUJQAFEP2L";
        const string TaskId= "IEACGXLUKQIGFGAK";

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

        [Test]
        public void GetAsync_ShouldReturnTimelogs()
        {
            var timelogs = WrikeClientFactory.GetWrikeClient().Timelogs.GetAsync().Result;
            Assert.IsNotNull(timelogs);
            Assert.GreaterOrEqual(timelogs.Count, 1);
        }   

        // TODO: test other get options fiwth taskId, contactId, folderId, timelogCategoryId

        [Test]
        public void CreateAsync_ShouldAddNewTimelogWithComment()
        {
            var newTimelog = new WrikeTimelog("IEACGXLUKQIGFGAK", "test timelog #2", 1m, DateTime.Now);
            var createdTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            Assert.IsNotNull(newTimelog);
            Assert.AreEqual(newTimelog.Comment, createdTimelog.Comment);

            //TODO: test other parameters
        }
        
        [Test]
        public void UpdateAsync_ShouldUpdateTimelogComment()
        {
            var newTimelog = new WrikeTimelog("IEACGXLUKQIGFGAK", "test timelog #2", 1m, DateTime.Now);
            newTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            var expectedComment = "test timelog #2 [Updated]";
            var updatedTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.UpdateAsync(newTimelog.Id, expectedComment).Result;

            Assert.IsNotNull(updatedTimelog);
            Assert.AreEqual(expectedComment, updatedTimelog.Comment);

            //TODO: test other parameters
        }

        [Test]
        public void DeleteAsync_ShouldDeleteNewTimelog()
        {
            var newTimelog = new WrikeTimelog("IEACGXLUKQIGFGAK", "test timelog #2", 1m, DateTime.Now);
            var createdTimelog = WrikeClientFactory.GetWrikeClient().Timelogs.CreateAsync(newTimelog).Result;

            WrikeClientFactory.GetWrikeClient().Timelogs.DeleteAsync(createdTimelog.Id).Wait();

            var timelogs = WrikeClientFactory.GetWrikeClient().Timelogs.GetAsync().Result;
            var isTimelogDeleted = !timelogs.Any(t => t.Id == createdTimelog.Id);

            Assert.IsTrue(isTimelogDeleted);
        }
    }
}

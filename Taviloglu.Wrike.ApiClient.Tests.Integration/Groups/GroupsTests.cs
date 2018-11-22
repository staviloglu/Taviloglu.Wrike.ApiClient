using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.Groups;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Groups
{
    [TestFixture, Order(9)]
    public class GroupsTests
    {
        const string DefaultGroupId = "KX74WSKU";        

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var groups = WrikeClientFactory.GetWrikeClient().Groups.GetAsync().Result;

            foreach (var group in groups)
            {
                if (group.Id != DefaultGroupId)
                {
                    WrikeClientFactory.GetWrikeClient().Groups.DeleteAsync(group.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnOneOrMoreGroup()
        {
            var groups = WrikeClientFactory.GetWrikeClient().Groups.GetAsync().Result;
            Assert.IsNotNull(groups);
            Assert.GreaterOrEqual(groups.Count, 1);
        }

        [Test, Order(2)]
        public void GetAsync_ShouldReturnDefaultGroupWithOptionalFields()
        {
            var optionalFields = new List<string> { WrikeGroup.OptionalFields.Metadata };

            var groups = WrikeClientFactory.GetWrikeClient().Groups.GetAsync(optionalFields: optionalFields).Result;
            Assert.IsNotNull(groups);
            Assert.GreaterOrEqual(groups.Count, 1);

            var defaultGroup = groups.First(g => g.Id == DefaultGroupId);

            Assert.AreEqual(DefaultGroupId, defaultGroup.Id);
            Assert.IsNotNull(defaultGroup.Metadata);
        }

        [Test, Order(3)]
        public void GetAsyncWithId_ShouldReturnDefaultGroup()
        {
            var group = WrikeClientFactory.GetWrikeClient().Groups.GetAsync(DefaultGroupId).Result;

            Assert.IsNotNull(group);
            Assert.AreEqual(DefaultGroupId, group.Id);
        }

        [Test, Order(4)]
        public void GetAsyncWithId_ShouldReturnDefaultGroupWithOptionalFields()
        {
            var optionalFields = new List<string> { WrikeGroup.OptionalFields.Metadata };

            var group = WrikeClientFactory.GetWrikeClient().Groups.GetAsync(DefaultGroupId, optionalFields: optionalFields).Result;

            Assert.IsNotNull(group);
            Assert.AreEqual(DefaultGroupId, group.Id);
            Assert.IsNotNull(group.Metadata);
        }


        [Test, Order(5)]
        public void CreateAsync_ShouldAddNewGroupWithTitle()
        {
            var newGroup = new WrikeGroup("Sinan's Test Group");
            var createdGroup = WrikeClientFactory.GetWrikeClient().Groups.CreateAsync(newGroup).Result;

            Assert.IsNotNull(createdGroup);
            Assert.AreEqual(newGroup.Title, createdGroup.Title);

            //TODO: test other parameters
        }
        
        [Test, Order(6)]
        public void UpdateAsync_ShouldUpdateGroupTitle()
        {
            var newGroup = new WrikeGroup("Sinan's Test Group");
            newGroup = WrikeClientFactory.GetWrikeClient().Groups.CreateAsync(newGroup).Result;

            var expectedGroupTitle = "Sinan's Test Group [Updated]";
            var updatedGroup = WrikeClientFactory.GetWrikeClient().Groups.UpdateAsync(newGroup.Id, expectedGroupTitle).Result;

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(expectedGroupTitle, updatedGroup.Title);

            //TODO: test other parameters
        }

        [Test, Order(7)]
        public void DeleteAsync_ShouldDeleteNewGroup()
        {
            var newGroup = new WrikeGroup("Sinan's Test Group");
            newGroup = WrikeClientFactory.GetWrikeClient().Groups.CreateAsync(newGroup).Result;

            WrikeClientFactory.GetWrikeClient().Groups.DeleteAsync(newGroup.Id).Wait();

            var groups = WrikeClientFactory.GetWrikeClient().Groups.GetAsync().Result;
            var isGroupDeleted = !groups.Any(g => g.Id == newGroup.Id);

            Assert.IsTrue(isGroupDeleted);
        }
    }
}

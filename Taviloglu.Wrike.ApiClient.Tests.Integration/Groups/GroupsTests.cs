using NUnit.Framework;
using System.Linq;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Groups
{
    [TestFixture]
    public class GroupsTests
    {
        WrikeClient _wrikeClient;
        const string DefaultGroupId = "KX74WSKU";
        [OneTimeSetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [OneTimeTearDown]
        public void RestoreGroupsToDefault()
        {
            var groups = _wrikeClient.Groups.GetAsync().Result;

            foreach (var group in groups)
            {
                if (group.Id != DefaultGroupId)
                {
                    _wrikeClient.Groups.DeleteAsync(group.Id).Wait();
                }
            }
        }

        [Test]
        public void GetAsync_ShouldReturnDefaultGroup()
        {
            RestoreGroupsToDefault();

            var groups = _wrikeClient.Groups.GetAsync().Result;
            Assert.IsNotNull(groups);
            Assert.AreEqual(1, groups.Count);
            Assert.AreEqual(DefaultGroupId, groups.First().Id);
        }


        [Test]
        public void CreateAsync_ShouldAddNewGroupWithTitle()
        {
            var newGroup = new WrikeGroup("Sinan's Test Group");

            var createdGroup = _wrikeClient.Groups.CreateAsync(newGroup).Result;

            Assert.IsNotNull(createdGroup);
            Assert.AreEqual(newGroup.Title, createdGroup.Title);
        }
        
        [Test]
        public void UpdateAsync_ShouldUpdateGroupTitle()
        {
            var newGroup = new WrikeGroup("Sinan's Test Group");
            newGroup = _wrikeClient.Groups.CreateAsync(newGroup).Result;

            var expectedGroupTitle = "Sinan's Test Group [Updated]";
            var updatedGroup = _wrikeClient.Groups.UpdateAsync(newGroup.Id, expectedGroupTitle).Result;

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(expectedGroupTitle, updatedGroup.Title);
        }

        [Test]
        public void DeleteAsync_ShouldDeleteNewGroup()
        {
            var newGroup = new WrikeGroup("Sinan's Test Group");
            newGroup = _wrikeClient.Groups.CreateAsync(newGroup).Result;

             _wrikeClient.Groups.DeleteAsync(newGroup.Id);

            var groups = _wrikeClient.Groups.GetAsync().Result;
            var isGroupDeleted = !groups.Any(g => g.Id == newGroup.Id);

            Assert.IsTrue(isGroupDeleted);
        }
    }
}

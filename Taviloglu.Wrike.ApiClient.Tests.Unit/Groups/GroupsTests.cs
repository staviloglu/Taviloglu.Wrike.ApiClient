using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Groups
{
    [TestFixture]
    public class GroupsTests
    {
        WrikeClient _wrikeClient;

        [OneTimeSetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [Test]
        public void GroupsProperty_ShouldReturnGroupsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeGroupsClient), _wrikeClient.Groups);
        }

        [Test]
        public void DeleteAsync_IdNull_ThrowArgumentNullException()
        {
            string id = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Groups.DeleteAsync(id));
        }

        [Test]
        public void DeleteAsync_IdEmpty_ThrowArgumentException()
        {
            string id = string.Empty;

            Assert.ThrowsAsync<ArgumentException>(() => _wrikeClient.Groups.DeleteAsync(id));
        }

        [Test]
        public void UpdateAsync_IdNull_ThrowArgumentNullException()
        {
            string id = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Groups.UpdateAsync(id));
        }

        [Test]
        public void UpdateAsync_IdEmpty_ThrowArgumentException()
        {
            string id = string.Empty;

            Assert.ThrowsAsync<ArgumentException>(() => _wrikeClient.Groups.UpdateAsync(id));
        }

        [Test]
        public void CreateAsync_NewGroupNull_ThrowArgumentNullException()
        {
            WrikeGroup newGroup = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Groups.CreateAsync(newGroup));
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Groups
{
    [TestFixture]
    public class GroupsTests
    {

        [Test]
        public void GroupsProperty_ShouldReturnGroupsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeGroupsClient), TestConstants.WrikeClient.Groups);
        }

        [Test]
        public void CreateAsync_NewGroupNull_ThrowArgumentNullException()
        {
            WrikeGroup newGroup = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Groups.CreateAsync(newGroup));
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Groups;

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
        public void GetAsyncAll_WhenOptionalFieldsNotInRange_ThrowArgumentOutOfRangeException()
        {
            var optionalFields = new List<string> { "wrongOptionalField", WrikeGroup.OptionalFields.Metadata };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.Groups.GetAsync(optionalFields: optionalFields));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeGroup.OptionalFields"));
        }

        [Test]
        public void GetAsyncWithId_WhenOptionalFieldsNotInRange_ThrowArgumentOutOfRangeException()
        {
            var optionalFields = new List<string> { "wrongOptionalField", WrikeGroup.OptionalFields.Metadata };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.Groups.GetAsync("Id",optionalFields: optionalFields));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeGroup.OptionalFields"));
        }

        [Test]
        public void CreateAsync_NewGroupNull_ThrowArgumentNullException()
        {
            WrikeGroup newGroup = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Groups.CreateAsync(newGroup));
            Assert.AreEqual("newGroup", ex.ParamName);
        }
    }
}

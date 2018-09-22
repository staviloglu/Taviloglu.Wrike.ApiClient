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
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void UpdateAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Groups.UpdateAsync(id));
        }

        [Test]
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void DeleteAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Groups.UpdateAsync(id));
        }


        [Test]
        public void CreateAsync_NewGroupNull_ThrowArgumentNullException()
        {
            WrikeGroup newGroup = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Groups.CreateAsync(newGroup));
        }
    }
}

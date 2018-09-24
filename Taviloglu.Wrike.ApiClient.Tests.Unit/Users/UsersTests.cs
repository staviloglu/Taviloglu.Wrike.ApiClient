using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Users;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Users
{
    [TestFixture]
    public class UsersTests
    {
        [Test]
        public void UsersProperty_ShouldReturnUsersClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeUsersClient), TestConstants.WrikeClient.Users);
        }

        [Test]
        public void UpdateAsync_ProfileNull_ThrowArgumentNullException()
        {
            WrikeUserProfile profile = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Users.UpdateAsync("id", profile));
            Assert.AreEqual("profile", ex.ParamName);
        }
    }
}

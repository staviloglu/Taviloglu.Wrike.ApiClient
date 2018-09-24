using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Users
{
    [TestFixture]
    public class UsersTests
    {
        const string DefaultUserId = "KUAERP25";

        [Test]
        public void GetAsync_ShouldRetunDefaultUser()
        {
            var user = WrikeClientFactory.GetWrikeClient().Users.GetAsync(DefaultUserId).Result;

            Assert.IsNotNull(user);
            Assert.AreEqual(DefaultUserId, user.Id);
            Assert.AreEqual("Sinan", user.FirstName);
            Assert.AreEqual("Taviloğlu", user.LastName);
            Assert.IsTrue(user.Me);

            //TODO: test other parameters
        }

        //TODO: test update

        //[Test]
        //public void UpdateAsync_ShouldRetunDefaultUser()
        //{
        //    var profile = new WrikeUserProfile("IEACGXLU", WrikeUserRole.User, false);

        //    var user = WrikeClientFactory.GetWrikeClient().Users.UpdateAsync(MyTeamUserId, profile).Result;

        //    Assert.IsNotNull(user);
        //    Assert.AreEqual(MyTeamUserId, user.Id);
        //    Assert.AreEqual(WrikeUserRole.User, user.Profiles[0].Role);

        //    //TODO: test other parameters
        //}
    }
}

using NUnit.Framework;

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
    }
}

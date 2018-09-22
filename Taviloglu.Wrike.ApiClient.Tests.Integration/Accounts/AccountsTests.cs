using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Accounts
{
    [TestFixture]
    public class AccountsTests
    {
        const string CurrentAccountId = "IEACGXLU";

        [Test]
        public void GetAsync_ShouldRetunCurrentAccount()
        {
            var actualAccount = WrikeClientFactory.GetWrikeClient().Accounts.GetAsync().Result;

            Assert.AreEqual(CurrentAccountId, actualAccount.Id);
        }
    }
}

using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Accounts
{
    [TestFixture]
    public class AccountsTests
    {
        [Test]
        public void AccountsProperty_ShouldReturnAccountsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeAccountsClient), TestConstants.WrikeClient.Accounts);
        }
    }
}

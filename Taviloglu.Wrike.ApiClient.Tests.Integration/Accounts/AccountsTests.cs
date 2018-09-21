using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Accounts
{
    [TestFixture]
    public class AccountsTests
    {
        WrikeClient _wrikeClient;

        const string CurrentAccountId = "IEACGXLU";

        [SetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [Test]
        public void GetAsync_ShouldRetunCurrentAccount()
        {
            var actualAccount = _wrikeClient.Accounts.GetAsync().Result;

            Assert.AreEqual(CurrentAccountId, actualAccount.Id);
        }
    }
}

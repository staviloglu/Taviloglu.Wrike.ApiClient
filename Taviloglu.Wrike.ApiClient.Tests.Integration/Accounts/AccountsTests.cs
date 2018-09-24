using NUnit.Framework;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;

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

        [Test]
        public void GetAsync_ShouldRetunCurrentAccountWithOptionalFields()
        {
            var optionalFields = new List<string> {
                WrikeAccount.OptionalFields.Metadata,
                WrikeAccount.OptionalFields.CustomFields,
                WrikeAccount.OptionalFields.Subscription
            };

            var actualAccount = WrikeClientFactory.GetWrikeClient().Accounts.GetAsync(fields: optionalFields).Result;

            Assert.AreEqual(CurrentAccountId, actualAccount.Id);
            Assert.IsNotNull(actualAccount.Subscription);
            Assert.IsNotNull(actualAccount.Metadata);
            Assert.IsNotNull(actualAccount.CustomFields);
        }
    }
}

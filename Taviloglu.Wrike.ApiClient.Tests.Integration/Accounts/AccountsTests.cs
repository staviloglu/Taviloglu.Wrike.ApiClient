using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Accounts
{
    [TestFixture]
    public class AccountsTests
    {
        const string CurrentAccountId = "IEACGXLU";
        const string TestMetaDataKey = "testMetadata";
        

        [OneTimeTearDown]
        public void RestoreToDefaults()
        {
            var defaultTestMetadataValue = "testMetadata";

            var metadataList = new List<WrikeMetadata> { new WrikeMetadata(TestMetaDataKey, defaultTestMetadataValue) };
            var account = WrikeClientFactory.GetWrikeClient().Accounts.UpdateAsync(metadataList).Result;
        }

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

        [Test]
        public void UpdateAsync_ShouldUpdateMetadataValue()
        {
            var expectedValue = "testMetadataValue [Updated]";

            var metadataList = new List<WrikeMetadata> { new WrikeMetadata(TestMetaDataKey, expectedValue) };

            var account = WrikeClientFactory.GetWrikeClient().Accounts.UpdateAsync(metadataList).Result;

            Assert.IsNotNull(account.Metadata);
            Assert.IsNotEmpty(account.Metadata);
            Assert.AreEqual(expectedValue, account.Metadata.First(md=> md.Key == TestMetaDataKey).Value);
        }
    }
}

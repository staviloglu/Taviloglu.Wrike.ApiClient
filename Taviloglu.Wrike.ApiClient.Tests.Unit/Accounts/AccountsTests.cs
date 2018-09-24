using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;

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

        [Test]
        public void GetAsync_WhenOptionalFieldsNotInRange_ThrowArgumentOutOfRangeException()
        {
            var optionalFields = new List<string> { "wrongOptionalField", WrikeAccount.OptionalFields.Subscription };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.Accounts.GetAsync(fields: optionalFields));
            Assert.AreEqual("fields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Use only values in WrikeAccount.OptionalFields"));
            
        }

        [Test]
        public void UpdateAsync_WhenMetadataListNull_ThrowArgumentNullException()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Accounts.UpdateAsync(null));
            Assert.AreEqual("metadataList", ex.ParamName);
        }

        [Test]
        public void UpdateAsync_WhenMetadataListEmpty_ThrowArgumentException()
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(() => TestConstants.WrikeClient.Accounts
            .UpdateAsync(new List<WrikeMetadata>()));
            Assert.AreEqual("metadataList", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }
    }
}

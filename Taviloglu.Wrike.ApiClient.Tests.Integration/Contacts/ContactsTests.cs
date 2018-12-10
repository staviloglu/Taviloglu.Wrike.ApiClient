using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Contacts
{
    [TestFixture, Order(5)]
    public class ContactsTests
    {
        const string DefaultContactId = "KUAERP25";
        const string WrikeBotContactId = "KUAERP3C";
        const string TestMetadataKey = "testMetaKey";
        const string TestMetadataValue = "testMetaValue";

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var updatedContact = WrikeClientFactory.GetWrikeClient().Contacts.UpdateAsync(DefaultContactId,
                new List<Core.WrikeMetadata> { new Core.WrikeMetadata(TestMetadataKey, TestMetadataValue) }).Result;
        }

        [Test, Order(1)]
        public void GetAsync_ShouldRetrunManyContacts()
        {
            var contacts = WrikeClientFactory.GetWrikeClient().Contacts.GetAsync().Result;
            
            Assert.GreaterOrEqual(contacts.Count,1 , "There should be more than one contact!");
        }

        [Test, Order(2)]
        public void GetAsync_WhenMe_ShouldReturnDefaultContact()
        {
            var contacts = WrikeClientFactory.GetWrikeClient().Contacts.GetAsync(me: true).Result;

            Assert.AreEqual(DefaultContactId, contacts.First().Id);
        }

        [Test, Order(3)]
        public void GetAsync_WhenIsDeleted_ShouldReturnZeroContacts()
        {
            var contacts = WrikeClientFactory.GetWrikeClient().Contacts.GetAsync(isDeleted: true).Result;

            var expectedContactCount = 0;

            Assert.AreEqual(expectedContactCount, contacts.Count);
        }

        [Test, Order(4)]
        public void GetAsync_WhenRetrieveMetadata_MetadataShouldNotBeNull()
        {
            var contacts = WrikeClientFactory.GetWrikeClient().Contacts.GetAsync(me:true, retrieveMetadata:true).Result;
            
            Assert.IsNotNull(contacts.First().Metadata);
        }

        [Test, Order(5)]
        public void GetAsync_WhenTwoIds_ShouldreturnTwoContacts()
        {
            var contactIds = new List<string>() { DefaultContactId, WrikeBotContactId };

            var contacts = WrikeClientFactory.GetWrikeClient().Contacts.GetAsync(contactIds).Result;

            var expectedContactCount = 2;

            Assert.AreEqual(expectedContactCount, contacts.Count);
        }

        [Test, Order(6)]
        public void GetAsync_WhenTwoIdsAndRetrieveMetadata_MetadataShouldNotBeNull()
        {
            var contactIds = new List<string>() { DefaultContactId, WrikeBotContactId };

            var contacts = WrikeClientFactory.GetWrikeClient().Contacts.GetAsync(contactIds, retrieveMetadata: true).Result;

            Assert.False(contacts.Any(c=> c.Metadata == null));
        }

        [Test, Order(7)]
        public void UpdateAsync_ShouldUpdateMetadata()
        {            
            var expectedMetaDataValue = "updatedMetaDataValue";
            var actualDefaultContact = WrikeClientFactory.GetWrikeClient().Contacts.UpdateAsync(DefaultContactId,
                new List<Core.WrikeMetadata> { new Core.WrikeMetadata(TestMetadataKey, expectedMetaDataValue) }).Result;
            Assert.AreEqual(expectedMetaDataValue, actualDefaultContact.Metadata.First().Value);

        }
    }
}

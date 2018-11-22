using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.CustomFields;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.CustomFields
{
    [TestFixture, Order(6)]
    public class CustomFieldsTests
    {
        public const string DefaultCustomFieldId = "IEACGXLUJUAAZZ4S";

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var customFields = WrikeClientFactory.GetWrikeClient().CustomFields.GetAsync().Result;

            foreach (var customField in customFields)
            {
                if (customField.Id != DefaultCustomFieldId)
                {
                    WrikeClientFactory.GetWrikeClient().Comments.DeleteAsync(customField.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnCustomFields()
        {
            var customFields = WrikeClientFactory.GetWrikeClient().CustomFields.GetAsync().Result;
            Assert.IsNotNull(customFields);
            Assert.Greater(customFields.Count, 0);
        }

        [Test, Order(2)]
        public void GetAsyncWithIds_ShouldReturnCustomFields()
        {
            var customFields = WrikeClientFactory.GetWrikeClient().CustomFields.GetAsync(new List<string> { DefaultCustomFieldId }).Result;
            Assert.IsNotNull(customFields);
            Assert.AreEqual(customFields.Count, 1);
            Assert.AreEqual(DefaultCustomFieldId, customFields.First().Id);
        }

        [Test, Order(3)]
        public void CreateAsync_ShouldAddCreateNewCustomField()
        {
            var newCustomField = new WrikeCustomField("TestCustomField#2", WrikeCustomFieldType.Text);
            var createdCustomField = WrikeClientFactory.GetWrikeClient().CustomFields.CreateAsync(newCustomField).Result;

            Assert.IsNotNull(newCustomField);
            Assert.AreEqual(newCustomField.Title, createdCustomField.Title);
            Assert.AreEqual(newCustomField.Type, createdCustomField.Type);

            //TODO: test other properties
        }

        [Test, Order(4)]
        public void UpdateAsync_ShouldUpdateCommentText()
        {
            var newCustomField = new WrikeCustomField("TestCustomField#3", WrikeCustomFieldType.Text);
            var createdCustomField = WrikeClientFactory.GetWrikeClient().CustomFields.CreateAsync(newCustomField).Result;

            var expectedTitle = "TestCustomField#3[Updated]";
            var expectedType = WrikeCustomFieldType.Checkbox;

            var updatedCustomField = WrikeClientFactory.GetWrikeClient().CustomFields.UpdateAsync(
                createdCustomField.Id, expectedTitle, expectedType).Result;

            Assert.IsNotNull(updatedCustomField);
            Assert.AreEqual(expectedTitle, updatedCustomField.Title);
            Assert.AreEqual(expectedType, updatedCustomField.Type);

            //TODO: test other properties
        }
    }
}

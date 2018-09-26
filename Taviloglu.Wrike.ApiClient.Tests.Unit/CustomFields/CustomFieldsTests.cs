using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.CustomFields;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.CustomFields
{
    [TestFixture]
    public class CustomFieldsTests
    {
        [Test]
        public void CustomFieldsProperty_ShouldReturnCustomFieldsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeCustomFieldsClient), TestConstants.WrikeClient.CustomFields);
        }

        [Test]
        public void CreateAsync_WhenCustomFieldNull_ThrowArgumentNullException()
        {
            WrikeCustomField newCustomField = null;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.CustomFields
            .CreateAsync(newCustomField));
            Assert.AreEqual("newCustomField", ex.ParamName);
        }
    }
}

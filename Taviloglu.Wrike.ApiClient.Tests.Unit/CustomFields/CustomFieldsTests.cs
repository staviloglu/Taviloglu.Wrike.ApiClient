using NUnit.Framework;

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
    }
}

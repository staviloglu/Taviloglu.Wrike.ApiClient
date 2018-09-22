using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Colors
{
    [TestFixture]
    public class ColorsTests
    {

        [Test]
        public void ColorsProperty_ShouldReturColorsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeColorsClient), TestConstants.WrikeClient.Colors);
        }
    }
}

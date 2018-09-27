using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Dependencies
{
    [TestFixture]
    public class DependenciesTests
    {

        [Test]
        public void DependenciesProperty_ShouldReturnDependenciesClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeDependenciesClient), TestConstants.WrikeClient.Dependencies);
        }
    }
}

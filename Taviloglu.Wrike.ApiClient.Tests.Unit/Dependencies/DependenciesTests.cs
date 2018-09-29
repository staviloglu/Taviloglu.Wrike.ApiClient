using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Dependencies;

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

        [Test]
        public void CreateAsync_NewDependencyNull_ThrowArgumentNullException()
        {
            WrikeDependency newDependency = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Dependencies.CreateAsync(newDependency));
            Assert.AreEqual("newDependency", ex.ParamName);
        }
    }
}

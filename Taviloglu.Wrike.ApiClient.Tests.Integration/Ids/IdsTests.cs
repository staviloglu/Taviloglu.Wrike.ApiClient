using NUnit.Framework;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Ids;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Ids
{
    [TestFixture]
    public class IdsTests
    {
        [Test]
        public void GetAsync_ShouldReturnDefaultGroup()
        {
            var groups = WrikeClientFactory.GetWrikeClient().Ids.GetAsync(WrikeEntityType.ApiV2Task,new List<int> { 2073775 }).Result;
            Assert.IsNotNull(groups);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Ids;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Ids
{
    [TestFixture]
    public class IdsTests
    {
        [Test]
        public void IdsProperty_ShouldReturnIdsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeIdsClient), TestConstants.WrikeClient.Ids);
        }

        [Test]
        public void GetAsync_WhenIdsNull_ThrowsArgumentNullException()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Ids.GetAsync(WrikeEntityType.ApiV2Task,null));
            Assert.AreEqual("ids", ex.ParamName);
        }

        [Test]
        public void GetAsync_WhenIdsEmptyString_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(() => TestConstants.WrikeClient.Ids.GetAsync(WrikeEntityType.ApiV2Task, new List<int>()));
            Assert.AreEqual("ids", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("value can not be empty"));
        }
    }
}

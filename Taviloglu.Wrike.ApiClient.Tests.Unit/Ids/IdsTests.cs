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
        [TestCaseSource(typeof(TestConstants), "StringListParameterCanNotBeNullOrEmpty")]
        public void GetAsyncWithIds_Throws<T>(T argumentException, List<string> ids) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Ids.GetAsync(WrikeEntityType.ApiV2Account,ids));
        }
    }
}

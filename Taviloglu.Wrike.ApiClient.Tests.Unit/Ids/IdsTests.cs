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
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Ids;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Ids
{
    [TestFixture]
    public class IdsTests
    {
        WrikeClient _wrikeClient;

        [OneTimeSetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [Test]
        public void IdsProperty_ShouldReturnIdsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeIdsClient), _wrikeClient.Ids);
        }

        [Test]
        public void GetAsync_ContactdsNull_ThrowArgumentNullException()
        {
            List<string> ids = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => _wrikeClient.Ids.GetAsync(WrikeEntityType.ApiV2Account, ids));
        }

        [Test]
        public void GetAsync_IdsEmpty_ThrowArgumentException()
        {
            var ids = new List<string>();

            Assert.ThrowsAsync<ArgumentException>(() => _wrikeClient.Ids.GetAsync(WrikeEntityType.ApiV2Account, ids));
        }
    }
}

using NUnit.Framework;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Version
{
    [TestFixture]
    public class VersionTests
    {
        WrikeClient _wrikeClient;
        [SetUp]
        public void Setup()
        {
            _wrikeClient = new WrikeClient("eyJ0dCI6InAiLCJhbGciOiJIUzI1NiIsInR2IjoiMSJ9.eyJkIjoie1wiYVwiOjIzMTc2ODQsXCJpXCI6NTM3NDAyNCxcImNcIjo0NTk1MDE0LFwidlwiOm51bGwsXCJ1XCI6NDc2NzU4MSxcInJcIjpcIlVTXCIsXCJzXCI6W1wiV1wiLFwiRlwiLFwiSVwiLFwiVVwiLFwiS1wiLFwiQ1wiXSxcInpcIjpbXSxcInRcIjowfSIsImlhdCI6MTUzNzMyMTkyOH0.r8MaouEsyTiWJ0qPqUt2McslSPP2NTinL9YrnQ9Lcow");
        }

        [Test]
        public void GetAsync_ShouldRetunMajor1Minor0()
        {
            var expectedWrikeVersion = new WrikeVersion {
                Major = "1",
                Minor = "0"
            };

            var actualWrikeVersion = _wrikeClient.Version.GetAsync().Result;

            Assert.AreEqual(expectedWrikeVersion.Major, actualWrikeVersion.Major);
            Assert.AreEqual(expectedWrikeVersion.Minor, actualWrikeVersion.Minor);
        }
    }
}

using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.FoldersAndProjects
{
    [TestFixture]
    public class FoldersAndProjectsTests
    {
        [Test]
        public void FoldersAndProjectsProperty_ShouldReturnFoldersAndProjectsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeFoldersAndProjectsClient), TestConstants.WrikeClient.FoldersAndProjects);
        }
    }
}

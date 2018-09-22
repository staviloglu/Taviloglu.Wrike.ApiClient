using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Comments
{
    [TestFixture]
    public class CommentsTests
    {
        [Test]
        public void CommentsProperty_ShouldReturnCommentsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeCommentsClient), TestConstants.WrikeClient.Comments);
        }
    }
}

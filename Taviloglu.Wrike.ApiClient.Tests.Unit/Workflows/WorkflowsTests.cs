using NUnit.Framework;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Workflows
{
    [TestFixture]
    public class WorkflowsTests
    {
        [Test]
        public void WorkflowsProperty_ShouldReturnWorkflowsClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeWorkflowsClient), TestConstants.WrikeClient.Workflows);
        }
    }
}

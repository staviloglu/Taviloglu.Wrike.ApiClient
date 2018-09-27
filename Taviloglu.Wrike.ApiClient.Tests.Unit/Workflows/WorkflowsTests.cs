using NUnit.Framework;
using System;
using Taviloglu.Wrike.Core.Workflows;

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

        [Test]
        public void CreateAsync_NewWorkflowNull_ThrowArgumentNullException()
        {
            WrikeWorkflow newWorkflow = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Workflows.CreateAsync(newWorkflow));
            Assert.AreEqual("newWorkflow", ex.ParamName);
        }
    }
}

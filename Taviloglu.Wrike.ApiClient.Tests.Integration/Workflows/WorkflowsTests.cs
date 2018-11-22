using NUnit.Framework;
using System;
using System.Linq;
using Taviloglu.Wrike.Core.Workflows;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Workflows
{
    [TestFixture, Order(18)]
    public class WorkflowsTests
    {
        const string DefaultWorkflowId = "IEACGXLUK775ZIUM"; //can not be updated!

        [Test, Order(1)]
        public void GetAsync_ShouldReturnWorkflows()
        {
            var workflows = WrikeClientFactory.GetWrikeClient().Workflows.GetAsync().Result;

            Assert.IsNotNull(workflows);
            Assert.GreaterOrEqual(workflows.Count, 1);
            Assert.IsTrue(workflows.Any(w => w.Id == DefaultWorkflowId));
        }

        [Test, Order(2)]
        public void CreateAsync_ShouldAddNewWorkflowWithName()
        {
            var newWorkflow = new WrikeWorkflow($"NewWorkflow#{DateTime.Now.ToString("yyyyMMddhhmmss")}");
            var createdWorkflow = WrikeClientFactory.GetWrikeClient().Workflows.CreateAsync(newWorkflow).Result;

            Assert.IsNotNull(createdWorkflow);
            Assert.AreEqual(newWorkflow.Name, createdWorkflow.Name);
            Assert.IsNotNull(createdWorkflow.CustomStatuses);
            Assert.GreaterOrEqual(createdWorkflow.CustomStatuses.Count, 0);

            //TODO: test other parameters
        }

        [Test, Order(3)]
        public void UpdateAsync_ShouldUpdateWorkflowName()
        {
            var newWorkflow = new WrikeWorkflow($"NewWorkflow#{DateTime.Now.ToString("yyyyMMddhhmmss")}");
            var createdWorkflow = WrikeClientFactory.GetWrikeClient().Workflows.CreateAsync(newWorkflow).Result;

            var expectedWorkflowName = $"{newWorkflow.Name} [Updated]";
            var updatedWorkflow = WrikeClientFactory.GetWrikeClient().Workflows.UpdateAsync(createdWorkflow.Id, expectedWorkflowName).Result;

            Assert.IsNotNull(updatedWorkflow);
            Assert.AreEqual(expectedWorkflowName, updatedWorkflow.Name);

            //TODO: test other parameters
        }
    }
}

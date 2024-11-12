using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Tests.Unit.Tasks
{
    [TestFixture]
    public class TasksTests
    {
        [Test]
        public void TasksProperty_ShouldReturnTasksClient()
        {
            Assert.IsInstanceOf(typeof(IWrikeTasksClient), TestConstants.WrikeClient.Tasks);
        }

        [Test]
        public void CreateAsync_NewTaskNull_ThrowArgumentNullException()
        {
            WrikeTask newTask = null;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => 
            TestConstants.WrikeClient.Tasks.CreateAsync("folderId", newTask));
            Assert.AreEqual("newTask", ex.ParamName);
        }

        [Test]        
        public void GetAsyncWithIds_WhenOptionalFieldsNotSupported_ThrowArgumentOutOfRangeException()
        {
            var notSupportedOptionalFields = new List<string> { WrikeTask.OptionalFields.Description };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.Tasks.GetAsync(new List<string> { "taskId1","taskId2"}, notSupportedOptionalFields));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Only Recurrent, AttachmentCount, EffortAllocation, CustomItemTypeId is supported."));
        }

        [Test]
        public void GetAsyncWithIds_WhenOptionalFieldsMoreThanTwo_ThrowArgumentOutOfRangeException()
        {
            var notSupportedOptionalFields = new List<string> { WrikeTask.OptionalFields.Description, WrikeTask.OptionalFields.DependencyIds, WrikeTask.OptionalFields.HasAttachments };

            var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => TestConstants.WrikeClient.Tasks.GetAsync(new List<string> { "taskId1", "taskId2" }, notSupportedOptionalFields));
            Assert.AreEqual("optionalFields", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("Only Recurrent, AttachmentCount, EffortAllocation, CustomItemTypeId is supported."));
        }
    }
}

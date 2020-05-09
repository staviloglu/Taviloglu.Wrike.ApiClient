using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.ApiClient.Tests.Integration.CustomFields;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Tasks
{
    [TestFixture, Order(12)]
    public class TasksTests
    {
        const string DefaultTaskId = "IEACGXLUKQO6DCNW";
        const string SubTaskId = "IEACGXLUKQO6DJPT";

        readonly List<string> DefaultTaskIds = new List<string> { DefaultTaskId, SubTaskId };

        const string PersonalFolderId = "IEACGXLUI4KZG6UV";

        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync().Result;

            foreach (var task in tasks)
            {
                if (!DefaultTaskIds.Contains(task.Id))
                {
                    WrikeClientFactory.GetWrikeClient().Tasks.DeleteAsync(task.Id).Wait();
                }
            }
        }

        [Test, Order(1)]
        public void GetAsync_ShouldReturnTasks()
        {
            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync().Result;
            Assert.IsNotNull(tasks);
            Assert.GreaterOrEqual(tasks.Count, DefaultTaskIds.Count);
        }

        [Test, Order(2)]
        public void GetAsyncWithIds_ShouldReturnDefaultTaskWithSubTask()
        {
            var supportedOptionalFields = new List<string> { WrikeTask.OptionalFields.Recurrent, WrikeTask.OptionalFields.AttachmentCount };

            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync(new List<string> { DefaultTaskId }, supportedOptionalFields).Result;
            Assert.IsNotNull(tasks);
            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual(DefaultTaskId,tasks[0].Id);
            Assert.IsTrue(tasks[0].SubTaskIds.Any());
            Assert.AreEqual(tasks[0].SubTaskIds[0], SubTaskId);
        }

        [Test, Order(3)]
        public void CreateAsync_ShouldAddNewTaskWithTitleAndEmptyCustomFieldData()
        {
            
            var newTask = new WrikeTask("Test Task #2", customFields: new List<WrikeCustomFieldData> { new WrikeCustomFieldData(CustomFieldsTests.DefaultCustomFieldId) });
            
            var createdTask = WrikeClientFactory.GetWrikeClient().Tasks.CreateAsync(PersonalFolderId, newTask).Result;

            Assert.IsNotNull(createdTask);
            Assert.AreEqual(newTask.Title, createdTask.Title);
        }

        [Test, Order(4)]
        public void UpdateAsync_ShouldUpdateTaskTitle()
        {
            var newTask = new WrikeTask("Test Task #3");
            newTask = WrikeClientFactory.GetWrikeClient().Tasks.CreateAsync(PersonalFolderId, newTask).Result;

            var expectedTaskTitle = "Test Task #3 [Updated]";
            var updatedTask = WrikeClientFactory.GetWrikeClient().Tasks.UpdateAsync(newTask.Id, expectedTaskTitle).Result;

            Assert.IsNotNull(updatedTask);
            Assert.AreEqual(expectedTaskTitle, updatedTask.Title);
        }

        [Test, Order(5)]
        public void DeleteAsync_ShouldDeleteNewTask()
        {
            var newTask = new WrikeTask("Test Task #4");
            var createdTask = WrikeClientFactory.GetWrikeClient().Tasks.CreateAsync(PersonalFolderId, newTask).Result;

            WrikeClientFactory.GetWrikeClient().Tasks.DeleteAsync(createdTask.Id).Wait();

            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync().Result;
            var isTaskDeleted = !tasks.Any(t => t.Id == createdTask.Id);

            Assert.IsTrue(isTaskDeleted);
        }
    }
}

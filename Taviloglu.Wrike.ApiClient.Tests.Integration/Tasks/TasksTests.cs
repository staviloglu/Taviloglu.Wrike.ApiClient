using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Tasks
{
    [TestFixture]
    public class TasksTests
    {
        readonly List<string> DefaultTaskIds = new List<string> { "IEACGXLUKQIGFGAK", "IEACGXLUKQIEQ6NC" };
        const string FolderId = "IEACGXLUI4IEQ6NG";

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

        [Test]
        public void GetAsync_ShouldReturnTasks()
        {
            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync().Result;
            Assert.IsNotNull(tasks);
            Assert.GreaterOrEqual(tasks.Count, 2);
        }

        [Test]
        public void GetAsyncWithIds_ShouldReturnDefaultTasks()
        {
            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync(DefaultTaskIds).Result;
            Assert.IsNotNull(tasks);
            Assert.AreEqual(2, tasks.Count);
            Assert.IsTrue(DefaultTaskIds.Contains(tasks[0].Id));
            Assert.IsTrue(DefaultTaskIds.Contains(tasks[1].Id));
        }        

        [Test]
        public void CreateAsync_ShouldAddNewTaskWithTitle()
        {
            var newTask = new WrikeTask("Test Task #2");
            var createdTask = WrikeClientFactory.GetWrikeClient().Tasks.CreateAsync(FolderId,newTask).Result;

            Assert.IsNotNull(createdTask);
            Assert.AreEqual(newTask.Title, createdTask.Title);

            //TODO: test other parameters
        }
        
        [Test]
        public void UpdateAsync_ShouldUpdateTaskTitle()
        {
            var newTask = new WrikeTask("Test Task #3");
            newTask = WrikeClientFactory.GetWrikeClient().Tasks.CreateAsync(FolderId, newTask).Result;

            var expectedTaskTitle = "Test Task #3 [Updated]";
            var updatedTask = WrikeClientFactory.GetWrikeClient().Tasks.UpdateAsync(newTask.Id, expectedTaskTitle).Result;

            Assert.IsNotNull(updatedTask);
            Assert.AreEqual(expectedTaskTitle, updatedTask.Title);

            //TODO: test other parameters
        }

        [Test]
        public void DeleteAsync_ShouldDeleteNewTask()
        {
            var newTask = new WrikeTask("Test Task #4");
            var createdTask = WrikeClientFactory.GetWrikeClient().Tasks.CreateAsync(FolderId, newTask).Result;

            WrikeClientFactory.GetWrikeClient().Tasks.DeleteAsync(createdTask.Id).Wait();

            var tasks = WrikeClientFactory.GetWrikeClient().Tasks.GetAsync().Result;
            var isTaskDeleted = !tasks.Any(t => t.Id == createdTask.Id);

            Assert.IsTrue(isTaskDeleted);
        }
    }
}

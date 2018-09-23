using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;

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
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void DeleteAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Tasks.DeleteAsync(id));
        }

        [Test]
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void CreateAsync_Throws<T>(T argumentException, string folderId) where T : ArgumentException
        {
            var newTask = new WrikeTask("Test Task");

            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Tasks.CreateAsync(folderId, newTask));
        }

        [Test]
        public void CreateAsync_NewTaskNull_ThrowArgumentNullException()
        {
            WrikeTask newTask = null;
            string folderId = "folderId";

            Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Tasks.CreateAsync(folderId, newTask));
        }

        [Test]
        [TestCaseSource(typeof(TestConstants), "StringListParameterCanNotBeNullOrEmptyAndCanNotHaveMoreThanHundredItems")]
        public void GetAsyncWithIds_Throws<T>(T argumentException, List<string> taskIds) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Tasks.GetAsync(taskIds));
        }

        [Test]
        [TestCaseSource(typeof(TestConstants), "SrtingParameterCanNotBeNullOrEmpty")]
        public void UpdateAsync_Throws<T>(T argumentException, string id) where T : ArgumentException
        {
            Assert.ThrowsAsync<T>(() => TestConstants.WrikeClient.Tasks.UpdateAsync(id));
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using Taviloglu.Wrike.Core;
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
            string folderId = "folderId";

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => TestConstants.WrikeClient.Tasks.CreateAsync(folderId, newTask));
            Assert.AreEqual("newTask", ex.ParamName);
        }
    }
}

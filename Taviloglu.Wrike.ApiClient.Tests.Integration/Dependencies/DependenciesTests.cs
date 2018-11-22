using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taviloglu.Wrike.ApiClient.Exceptions;
using Taviloglu.Wrike.Core.Dependencies;

namespace Taviloglu.Wrike.ApiClient.Tests.Integration.Dependencies
{
    [TestFixture, Order(7)]
    public class DependenciesTests
    {

        const string DefaultDependencyId = "IEACGXLUIUIHWJQTKMIHWJQX";
        const string PredecessorTaskId = "IEACGXLUKQIHWJQW";
        const string DependentTaskId = "IEACGXLUKQIHWJQT";
        const string SuccessorTaskId = "IEACGXLUKQIHWJQX";

        readonly List<string> TaskIds = new List<string>{ PredecessorTaskId, SuccessorTaskId, DependentTaskId };


        [OneTimeTearDown]
        public void ReturnToDefaults()
        {
            foreach (var taskId in TaskIds)
            {
                var dependencies = WrikeClientFactory.GetWrikeClient().Dependencies.GetInTaskAsync(taskId).Result;
                foreach (var dependency in dependencies)
                {
                    if (dependency.Id != DefaultDependencyId)
                    {
                        WrikeClientFactory.GetWrikeClient().Dependencies.DeleteAsync(dependency.Id);
                    }                    
                }
            }
        }

        [Test, Order(1)]
        public void GetAsyncInTask_ShouldReturnOneOrMoreDependency()
        {
            var dependencies = WrikeClientFactory.GetWrikeClient().Dependencies.GetInTaskAsync(DependentTaskId).Result;
            Assert.IsNotNull(dependencies);
            Assert.GreaterOrEqual(dependencies.Count, 1);
        }

        [Test, Order(2)]
        public void GetAsyncWithIds_ShouldReturnDefaultDependency()
        {
            var dependencies = WrikeClientFactory.GetWrikeClient().Dependencies.GetAsync(new List<string> { DefaultDependencyId }).Result;
            Assert.IsNotNull(dependencies);
            Assert.AreEqual(1, dependencies.Count);
            Assert.AreEqual(DefaultDependencyId, dependencies[0].Id);
        }

        [Test, Order(3)]
        public void CreateAsync_ShouldCreateDependencyFromPredecessorTaskToDependatnTask()
        {
            var newDependency = new WrikeDependency(PredecessorTaskId, DependentTaskId, WrikeDependencyRelationType.FinishToStart);
            newDependency = WrikeClientFactory.GetWrikeClient().Dependencies.CreateAsync(newDependency).Result;

            Assert.IsNotNull(newDependency);
            Assert.AreEqual(PredecessorTaskId, newDependency.PredecessorId);
            Assert.AreEqual(DependentTaskId, newDependency.SuccessorId);
        }

        [Test, Order(4)]
        public void DeleteAsync_ShouldDeleteDependency()
        {
            var newDependency = new WrikeDependency(PredecessorTaskId, SuccessorTaskId, WrikeDependencyRelationType.StartToFinish);
            newDependency = WrikeClientFactory.GetWrikeClient().Dependencies.CreateAsync(newDependency).Result;

            WrikeClientFactory.GetWrikeClient().Dependencies.DeleteAsync(newDependency.Id);

            var dependencies = WrikeClientFactory.GetWrikeClient().Dependencies.GetInTaskAsync(PredecessorTaskId).Result;
            var isDependencyDeleted = !dependencies.Any(d => d.Id == newDependency.Id);
            Assert.IsTrue(isDependencyDeleted);
        }
    }
}

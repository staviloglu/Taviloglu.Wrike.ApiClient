using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Dependencies;

namespace Taviloglu.Wrike.ApiClient.Samples
{
    public static class DependenciesSamples
    {
        const string PredecessorTaskId = "IEACGXLUKQIHWJQW";
        const string DependentTaskId = "IEACGXLUKQIHWJQT";
        const string SuccessorTaskId = "IEACGXLUKQIHWJQX";

        public static async Task Run(WrikeClient client)
        {
            await client.Dependencies.DeleteAsync("aads");

            var dependencies = await client.Dependencies.GetInTaskAsync(DependentTaskId);

            var newDependency = new WrikeDependency(DependentTaskId, SuccessorTaskId, WrikeDependencyRelationType.FinishToStart);
            newDependency = await client.Dependencies.CreateAsync(newDependency);

            dependencies = await client.Dependencies.GetInTaskAsync(DependentTaskId);
            

            dependencies = await client.Dependencies.GetInTaskAsync(DependentTaskId);

            //var newWrikeDependencyWithSuccessor = new WrikeDependencyWithSuccessor(SuccessorTaskId, WrikeDependencyRelationType.FinishToFinish);
            //newWrikeDependencyWithSuccessor = await client.Dependencies.CreateAsync(DependentTaskId, newWrikeDependencyWithSuccessor);





            //await client.Dependencies.DeleteAsync(newDependency.Id);
        }
    }
}

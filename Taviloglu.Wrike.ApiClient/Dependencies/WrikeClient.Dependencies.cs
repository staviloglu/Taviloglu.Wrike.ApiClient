using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core.Dependencies;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeDependenciesClient
    {
        public IWrikeDependenciesClient Dependencies { get { return (IWrikeDependenciesClient)this; } }

        async Task<List<WrikeDependency>> IWrikeDependenciesClient.GetInTaskAsync(WrikeClientIdParameter taskId)
        {
            var response = await SendRequest<WrikeDependency>($"tasks/{taskId}/dependencies", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeDependency>> IWrikeDependenciesClient.GetAsync(WrikeClientIdListParameter ids)
        {
            var response = await SendRequest<WrikeDependency>($"dependencies/{ids}", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeDependency> IWrikeDependenciesClient.CreateAsync(WrikeDependency newDependency)
        {

            if (newDependency == null)
            {
                throw new ArgumentNullException(nameof(newDependency));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("relationType", newDependency.RelationType);

            contentBuilder.AddParameter("successorId", newDependency.SuccessorId);

            var response = await SendRequest<WrikeDependency>($"tasks/{newDependency.PredecessorId}/dependencies", HttpMethods.Post, contentBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeDependency> IWrikeDependenciesClient.UpdateAsync(WrikeClientIdParameter id, WrikeDependencyRelationType relationType)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("relationType", relationType);

            var response = await SendRequest<WrikeDependency>($"dependencies/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);

            return GetReponseDataFirstItem(response);
        }

        async Task IWrikeDependenciesClient.DeleteAsync(WrikeClientIdParameter id)
        {
            await SendRequest<WrikeDependency>($"dependencies/{id}", HttpMethods.Delete).ConfigureAwait(false);
        }
    }
}

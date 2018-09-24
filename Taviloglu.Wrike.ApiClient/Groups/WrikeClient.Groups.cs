using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeGroupsClient
    {
        public IWrikeGroupsClient Groups { get { return (IWrikeGroupsClient)this; } }

        async Task IWrikeGroupsClient.DeleteAsync(WrikeClientIdParameter id, bool isTest)
        {
            var requestUri = $"groups/{id}";

            if (isTest)
            {
                requestUri += "?test=true";
            }

            await SendRequest<WrikeGroup>(requestUri, HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<WrikeGroup> IWrikeGroupsClient.GetAsync(WrikeClientIdParameter id, List<string> optionalFields)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeGroup.OptionalFields.List).Any())
            {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeGroup.OptionalFields");
            }

            var uriBuilder = new WrikeGetUriBuilder($"groups/{id}")
           .AddParameter("fields", optionalFields);

            var response = await SendRequest<WrikeGroup>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<List<WrikeGroup>> IWrikeGroupsClient.GetAsync(List<string> optionalFields, WrikeMetadata metaDataFilter)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeGroup.OptionalFields.List).Any())
            {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeGroup.OptionalFields");
            }

            var uriBuilder = new WrikeGetUriBuilder("groups")
            .AddParameter("metadata", metaDataFilter)
            .AddParameter("fields", optionalFields);

            var response = await SendRequest<WrikeGroup>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeGroup> IWrikeGroupsClient.CreateAsync(WrikeGroup newGroup, string parentId, WrikeGroupAvatar avatar)
        {
            if (newGroup == null)
            {
                throw new ArgumentNullException(nameof(newGroup));
            }

            var requestUri = $"groups";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", newGroup.Title)
                .AddParameter("members", newGroup.MemberIds)
                .AddParameter("parent", parentId)
                .AddParameter("avatar", avatar)
                .AddParameter("metadata", newGroup.Metadata);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeGroup>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeGroup> IWrikeGroupsClient.UpdateAsync(WrikeClientIdParameter id, string title, List<string> membersToAdd, List<string> membersToRemove, string parentId, WrikeGroupAvatar avatar, List<WrikeMetadata> metaData)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", title)
                .AddParameter("addMembers", membersToAdd)
                .AddParameter("removeMembers", membersToRemove)
                .AddParameter("parent", parentId)
                .AddParameter("avatar", avatar)
                .AddParameter("metadata", metaData);

            var response = await SendRequest<WrikeGroup>($"groups/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

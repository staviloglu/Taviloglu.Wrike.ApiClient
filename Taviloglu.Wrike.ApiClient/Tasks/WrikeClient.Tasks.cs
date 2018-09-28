using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.Json;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTasksClient
    {
        private string _lastNextPageToken;
        string IWrikeTasksClient.LastNextPageToken { get { return _lastNextPageToken; } }

        private int _lastResponseSize;
        int IWrikeTasksClient.LastResponseSize { get { return _lastResponseSize; } }

        public IWrikeTasksClient Tasks
        {
            get
            {
                return (IWrikeTasksClient)this;
            }
        }

        async Task<WrikeTask> IWrikeTasksClient.CreateAsync(WrikeClientIdParameter folderId, WrikeTask newTask, string priorityBefore, string priorityAfter)
        {
            if (newTask == null)
            {
                throw new ArgumentNullException(nameof(newTask));
            }

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", newTask.Title)
                .AddParameter("description", newTask.Description)
                .AddParameter("importance", newTask.Importance)
                .AddParameter("dates", newTask.Dates)
                .AddParameter("shareds", newTask.SharedIds)
                .AddParameter("parents", newTask.ParentIds)
                .AddParameter("responsibles", newTask.ResponsibleIds)
                .AddParameter("followers", newTask.FollowerIds)
                .AddParameter("follow", newTask.FollowedByMe)
                .AddParameter("priorityBefore", priorityBefore)
                .AddParameter("priorityAfter", priorityAfter)
                .AddParameter("superTasks", newTask.SuperTaskIds)
                .AddParameter("metadata", newTask.Metadata)
                .AddParameter("customFields", newTask.CustomFields);

            if (string.IsNullOrWhiteSpace(newTask.CustomStatusId))
            {
                postDataBuilder.AddParameter("status", newTask.Status);
            }
            else
            {
                postDataBuilder.AddParameter("customStatus", newTask.CustomStatusId);
            }
            
            var response = await SendRequest<WrikeTask>($"folders/{folderId}/tasks", HttpMethods.Post, postDataBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeTask> IWrikeTasksClient.DeleteAsync(WrikeClientIdParameter id)
        {
            var response = await SendRequest<WrikeTask>($"tasks/{id}", HttpMethods.Delete).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<List<WrikeTask>> IWrikeTasksClient.GetAsync(string folderId, bool? addDescendants, string title, WrikeTaskStatus? status, WrikeTaskImportance? importance, IWrikeDateFilter startDate, IWrikeDateFilter dueDate, IWrikeDateFilter scheduledDate, WrikeDateFilterRange createdDate, WrikeDateFilterRange updatedDate, WrikeDateFilterRange completedDate, List<string> authors, List<string> responsibles, List<string> shareds, string permalink, WrikeTaskDateType? type, int? limit, WrikeTaskSortField? sortField, WrikeSortOrder? sortOrder, bool? addSubTasks, int? pageSize, string nextPageToken, WrikeMetadata metadata, WrikeCustomFieldData customField, List<string> customStatuses, List<string> fields)
        {
            var requestUri = "tasks";

            if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = $"folders/{folderId}/tasks";
            }

            var uriBuilder = new WrikeUriBuilder(requestUri)
            .AddParameter("descendants", addDescendants)
            .AddParameter("title", title)
            .AddParameter("status", status)
            .AddParameter("importance", importance)
            .AddParameter("startDate", startDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss"))
            .AddParameter("dueDate", dueDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss"))
            .AddParameter("scheduledDate", scheduledDate, new CustomDateTimeConverter("yyyy-MM-dd"))
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("updatedDate", updatedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("completedDate", completedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("authors", authors)
            .AddParameter("responsibles", responsibles)
            .AddParameter("shareds", shareds)
            .AddParameter("permalink", permalink)
            .AddParameter("type", type)
            .AddParameter("limit", limit)
            .AddParameter("sortField", sortField)
            .AddParameter("sortOrder", sortOrder)
            .AddParameter("subTasks", addSubTasks)
            .AddParameter("pageSize", pageSize)
            .AddParameter("nextPageToken", nextPageToken)
            .AddParameter("metadata", metadata)
            .AddParameter("customField", customField)
            .AddParameter("customStatuses", customStatuses)
            .AddParameter("fields", fields);

            var response = await SendRequest<WrikeTask>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            
            _lastResponseSize = response.ResponseSize;
            _lastNextPageToken = response.NextPageToken;
            

            return GetReponseDataList(response);
        }

        async Task<List<WrikeTask>> IWrikeTasksClient.GetAsync(WrikeClientIdListParameter taskIds, List<string> optionalFields)
        {
            var supportedOptionalFields = new List<string> { WrikeTask.OptionalFields.Recurrent, WrikeTask.OptionalFields.AttachmentCount };

            if (optionalFields != null &&
                (optionalFields.Count > 2 ||
                optionalFields.Any(o => !supportedOptionalFields.Contains(o))))
            {
                throw new ArgumentOutOfRangeException(nameof(optionalFields),"Only Recurrent and AttachmentCount is supported.");
            }

            var uriBuilder = new WrikeUriBuilder($"tasks/{taskIds}")
                .AddParameter("fields",optionalFields);

            var response = await SendRequest<WrikeTask>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            
            //TODO: can not get recurrent property even it is provided bug?

            return GetReponseDataList(response);
        }

        async Task<WrikeTask> IWrikeTasksClient.UpdateAsync(
            WrikeClientIdParameter id,
            string title,
            string description,
            WrikeTaskStatus? status,
            WrikeTaskImportance? importance,
            WrikeTaskDate dates,
            List<string> addParents,
            List<string> removeParents,
            List<string> addShareds,
            List<string> removeShareds,
            List<string> addResponsibles,
            List<string> removeResponsibles,
            List<string> addFollowers,
            bool? follow,
            string priorityBefore,
            string priorityAfter,
            List<string> addSuperTasks,
            List<string> removeSuperTasks,
            List<WrikeMetadata> metadata,
            List<WrikeCustomFieldData> customFields,
            string customStatus,
            bool? restore)
        {
            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", title)
                .AddParameter("description", description)
                .AddParameter("status", status)
                .AddParameter("importance", importance)
                .AddParameter("dates", dates)
                .AddParameter("addParents", addParents)
                .AddParameter("removeParents", removeParents)
                .AddParameter("addShareds", addShareds)
                .AddParameter("removeShareds", removeShareds)
                .AddParameter("addResponsibles", addResponsibles)
                .AddParameter("removeResponsibles", removeResponsibles)
                .AddParameter("addFollowers", addFollowers)
                .AddParameter("follow", follow)
                .AddParameter("priorityBefore", priorityBefore)
                .AddParameter("priorityAfter", priorityAfter)
                .AddParameter("addSuperTasks", addSuperTasks)
                .AddParameter("removeSuperTasks", removeSuperTasks)
                .AddParameter("metadata", metadata)
                .AddParameter("customFields", customFields)
                .AddParameter("customStatus", customStatus)
                .AddParameter("restore", restore);

            var response = await SendRequest<WrikeTask>($"tasks/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

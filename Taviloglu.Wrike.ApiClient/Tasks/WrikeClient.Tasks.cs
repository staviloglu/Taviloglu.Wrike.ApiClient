using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeTasksClient
    {
        public IWrikeTasksClient Tasks
        {
            get
            {
                return (IWrikeTasksClient)this;
            }
        }

        async Task<WrikeTask> IWrikeTasksClient.CreateAsync(string folderId, WrikeTask newTask, string priorityBefore, string priorityAfter)
        {
            if (string.IsNullOrWhiteSpace(folderId))
            {
                throw new ArgumentNullException("folderId can not be null or empty");
            }

            if (newTask == null)
            {
                throw new ArgumentNullException("newTask can not be null");
            }

            if (string.IsNullOrWhiteSpace(newTask.Title))
            {
                throw new ArgumentNullException("newTask.Title can not be null or empty");
            }

            var requestUri = $"folders/{folderId}/tasks";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", newTask.Title)
                .AddParameter("description", newTask.Description)
                .AddParameter("status", newTask.Status)
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
                .AddParameter("customFields", newTask.CustomFields)
                .AddParameter("customStatus", newTask.CustomStatusId);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeTask>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeTask> IWrikeTasksClient.DeleteAsync(string taskId)
        {

            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException("taskId can not be null or empty");
            }

            var response = await SendRequest<WrikeTask>($"tasks/{taskId}", HttpMethods.Delete).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<List<WrikeTask>> IWrikeTasksClient.GetAsync(string accountId, string folderId, bool? addDescendants, string title, WrikeTaskStatus? status, WrikeTaskImportance? importance, IWrikeDateFilter startDate, IWrikeDateFilter dueDate, IWrikeDateFilter scheduledDate, WrikeDateFilterRange createdDate, WrikeDateFilterRange updatedDate, WrikeDateFilterRange completedDate, List<string> authors, List<string> responsibles, List<string> shareds, string permalink, WrikeTaskDateType? type, int? limit, WrikeTaskSortField? sortField, WrikeSortOrder? sortOrder, bool? addSubTasks, int? pageSize, string nextPageToken, WrikeMetadata metadata, WrikeCustomFieldData customField, List<string> customStatuses, List<string> fields)
        {
            if (!string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(folderId))
            {
                throw new ArgumentException("only folderId or accountId can be used, not both!");
            }

            var requestUri = "tasks";

            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/tasks";
            }
            else if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = $"folders/{folderId}/tasks";
            }

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
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
            return GetReponseDataList(response);
        }

        async Task<List<WrikeTask>> IWrikeTasksClient.GetAsync(List<string> taskIds, List<string> optionalFields)
        {


            if (taskIds == null || taskIds.Count < 1)
            {
                throw new ArgumentNullException("taskIds can not be null or empty");
            }
            if (taskIds.Count > 100)
            {
                throw new ArgumentException("taskIds max count is 100");
            }
            if (optionalFields != null &&
                (optionalFields.Count > 2 ||
                optionalFields.Any(o => o != WrikeTask.OptionalFields.Recurrent && o != WrikeTask.OptionalFields.AttachmentCount)))
            {
                throw new ArgumentException("Only Recurrent and AttachmentCount is supported.");
            }
            var requestUri = "tasks/" + string.Join(",", taskIds);

            if (optionalFields != null && optionalFields.Count > 0)
            {
                requestUri += "?fields=" + JsonConvert.SerializeObject(optionalFields);
            }

            var response = await SendRequest<WrikeTask>(requestUri, HttpMethods.Get).ConfigureAwait(false);
            //TODO: can not get recurrent property even it is provided bug?
            return GetReponseDataList(response);
        }

        async Task<WrikeTask> IWrikeTasksClient.UpdateAsync(
            string taskId,
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
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException("taskId can not be null");
            }

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

            var response = await SendRequest<WrikeTask>($"tasks/{taskId}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

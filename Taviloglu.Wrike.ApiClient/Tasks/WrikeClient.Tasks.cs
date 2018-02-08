using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
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
        
        async Task<WrikeResDto<WrikeTask>> IWrikeTasksClient.CreateAsync(string folderId, WrikeTask newTask, string priorityBefore, string priorityAfter)
        {
            //TODO: implement            
            //return await SendRequest<WrikeTask>($"api/v3/folders/{folderId}/tasks", HttpMethods.Post, postData);
            return new WrikeResDto<WrikeTask>();
        }

        async Task<WrikeResDto<WrikeTask>> IWrikeTasksClient.DeleteAsync(string taskId)
        {

            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException("taskId can not be null or empty");
            }

            return await SendRequest<WrikeTask>($"tasks/{taskId}", HttpMethods.Delete);
        }

        async Task<WrikeResDto<WrikeTask>> IWrikeTasksClient.GetAsync(string accountId, string folderId, bool? addDescendants, string title, WrikeTaskStatus? status, WrikeTaskImportance? importance, IWrikeDateFilter startDate, IWrikeDateFilter dueDate, IWrikeDateFilter scheduledDate, WrikeDateFilterRange createdDate, WrikeDateFilterRange updatedDate, WrikeDateFilterRange completedDate, List<string> authors, List<string> responsibles, List<string> shareds, string permalink, WrikeTaskDateType? type, int? limit, WrikeTaskSortField? sortField, WrikeSortOrder? sortOrder, bool? addSubTasks, int? pageSize, string nextPageToken, WrikeMetadata metadata, WrikeCustomFieldData customField, List<string> customStatuses, List<string> fields)
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

            var filterHelper = new WrikeGetParametersHelper();
            filterHelper.AddFilterIfNotNull("descendants", addDescendants);
            filterHelper.AddFilterIfNotNull("title", title);
            filterHelper.AddFilterIfNotNull("status", status);
            filterHelper.AddFilterIfNotNull("importance", importance);
            filterHelper.AddFilterIfNotNull("startDate", startDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss"));
            filterHelper.AddFilterIfNotNull("dueDate", dueDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss"));
            filterHelper.AddFilterIfNotNull("scheduledDate", scheduledDate, new CustomDateTimeConverter("yyyy-MM-dd"));
            filterHelper.AddFilterIfNotNull("createdDate", 
                createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            filterHelper.AddFilterIfNotNull("updatedDate", 
                updatedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            filterHelper.AddFilterIfNotNull("completedDate", 
                completedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            filterHelper.AddFilterIfNotNull("authors", authors);
            filterHelper.AddFilterIfNotNull("responsibles", responsibles);
            filterHelper.AddFilterIfNotNull("shareds", shareds);
            filterHelper.AddFilterIfNotNull("permalink", permalink);
            filterHelper.AddFilterIfNotNull("type", type);
            filterHelper.AddFilterIfNotNull("limit", limit);
            filterHelper.AddFilterIfNotNull("sortField", sortField);
            filterHelper.AddFilterIfNotNull("sortOrder", sortOrder);
            filterHelper.AddFilterIfNotNull("subTasks", addSubTasks);
            filterHelper.AddFilterIfNotNull("pageSize", pageSize);
            filterHelper.AddFilterIfNotNull("nextPageToken", nextPageToken);
            filterHelper.AddFilterIfNotNull("metadata", metadata);
            filterHelper.AddFilterIfNotNull("customField", customField);
            filterHelper.AddFilterIfNotNull("customStatuses", customStatuses);
            filterHelper.AddFilterIfNotNull("fields", fields);
            
            requestUri += filterHelper.GetFilterParametersText();

            return await SendRequest<WrikeTask>(requestUri, HttpMethods.Get);
        }

        async Task<WrikeResDto<WrikeTask>> IWrikeTasksClient.GetAsync(List<string> taskIds, List<string> optionalFields)
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

            //TODO: can not get recurrent property even it is provided bug?
            return await SendRequest<WrikeTask>(requestUri, HttpMethods.Get);
        }
    }
}

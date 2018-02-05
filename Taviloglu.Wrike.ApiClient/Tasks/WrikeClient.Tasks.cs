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
        async Task<WrikeResDto<WrikeTask>> IWrikeTasksClient.CreateAsync(string folderId)
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

        async Task<WrikeResDto<WrikeTask>> IWrikeTasksClient.GetAsync(string accountId, string folderId, bool? addDescendents, string title, WrikeTaskStatus? status, WrikeTaskImportance? importance, IWrikeDateFilter startDate, IWrikeDateFilter dueDate, IWrikeDateFilter scheduledDate, WrikeDateFilterRange createdDate, WrikeDateFilterRange updatedDate, WrikeDateFilterRange completedDate, List<string> authors, List<string> responsibles, List<string> shareds, string permalink, WrikeTaskDateType? type, int? limit, WrikeTaskSortField? sortField, WrikeSortOrder? sortOrder, bool? addSubTasks, int? pageSize, string nextPageToken, WrikeMetadata metadata, WrikeCustomFieldData customField, List<string> customStatuses, List<string> optionalFields)
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

            List<string> filters = new List<string>();

            #region filters            
            if (addDescendents != null && addDescendents.Value == true)
            {
                filters.Add("descendants=true");

            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                filters.Add($"title={title}");
            }
            if (status != null)
            {
                filters.Add($"status={status}");
            }
            if (importance != null)
            {
                filters.Add($"importance={importance}");
            }
            if (startDate != null)
            {
                filters.Add("startDate=" + JsonConvert.SerializeObject(startDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss")));
            }
            if (dueDate != null)
            {
                filters.Add("dueDate=" + JsonConvert.SerializeObject(dueDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss")));
            }
            if (scheduledDate != null)
            {
                filters.Add("scheduledDate=" + JsonConvert.SerializeObject(
                    scheduledDate, new CustomDateTimeConverter("yyyy-MM-dd")));
            }
            if (createdDate != null)
            {
                filters.Add("createdDate=" + JsonConvert.SerializeObject(createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'")));
            }
            if (updatedDate != null)
            {
                filters.Add("updatedDate=" + JsonConvert.SerializeObject(updatedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'")));
            }
            if (completedDate != null)
            {
                filters.Add("completedDate=" + JsonConvert.SerializeObject(completedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'")));
            }
            if (authors != null && authors.Count > 0)
            {
                filters.Add("authors=" + JsonConvert.SerializeObject(authors));
            }
            if (responsibles != null && responsibles.Count > 0)
            {
                filters.Add("responsibles=" + JsonConvert.SerializeObject(responsibles));
            }
            if (shareds != null && shareds.Count > 0)
            {
                filters.Add("shareds=" + JsonConvert.SerializeObject(shareds));
            }
            if (!string.IsNullOrWhiteSpace(permalink))
            {
                filters.Add($"permalink={permalink}");
            }
            if (type != null)
            {
                filters.Add($"type={type}");
            }
            if (limit != null && limit > 0)
            {
                filters.Add($"limit={limit}");
            }
            if (sortField != null)
            {
                filters.Add($"sortField={sortField}");
            }
            if (sortOrder != null)
            {
                filters.Add($"sortOrder={sortOrder}");
            }
            if (addSubTasks != null && addSubTasks.Value == true)
            {
                filters.Add("subTasks=true");
            }
            if (pageSize != null && pageSize > 0)
            {
                filters.Add($"pageSize={pageSize}");
            }
            if (!string.IsNullOrWhiteSpace(nextPageToken))
            {
                filters.Add($"nextPageToken={nextPageToken}");
            }
            if (metadata != null)
            {
                filters.Add("metadata=" + JsonConvert.SerializeObject(metadata));
            }
            if (customField != null)
            {
                filters.Add("customField=" + JsonConvert.SerializeObject(customField));
            }
            if (customStatuses != null && customStatuses.Count > 0)
            {
                filters.Add("customStatuses=" + JsonConvert.SerializeObject(customStatuses));
            }
            if (optionalFields != null && optionalFields.Count > 0)
            {
                filters.Add("fields=" + JsonConvert.SerializeObject(optionalFields));
            }
            #endregion

            if (filters.Count > 0)
            {
                requestUri += "?" + string.Join("&", filters);
            }

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

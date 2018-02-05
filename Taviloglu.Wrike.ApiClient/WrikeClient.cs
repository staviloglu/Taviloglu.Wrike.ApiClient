using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Provides methods to access and modify user content in Wrike through the API
    /// </summary>
    public class WrikeClient
    {
        private readonly HttpClient _httpClient;
        public WrikeClient(string bearerToken)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(@"https://www.wrike.com/api/v3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
        }

        #region Users
        /// <summary>
        ///  Returns information about single user. 
        ///  Scopes: amReadOnlyUser, amReadWriteUser
        /// </summary>
        /// <param name="id">userId</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-user"/>
        public async Task<WrikeResDto<WrikeUser>> GetUserAsync(string id)
        {
            return await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get);
        }
        #endregion

        #region Tasks
        /// <summary>
        ///  Create task in folder. You can specify rootFolderId to create task in user's account root. 
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="folderId">folderId</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-task"/>
        public async Task<WrikeResDto<WrikeTask>> CreateTaskAsync(string folderId)
        {
            //TODO: implement            
            //return await SendRequest<WrikeTask>($"api/v3/folders/{folderId}/tasks", HttpMethods.Post, postData);
            return new WrikeResDto<WrikeTask>();
        }

        /// <summary>
        /// Delete task by Id
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-tasks"/>        
        public async Task<WrikeResDto<WrikeTask>> Delete(string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentNullException("taskId can not be null or empty");
            }

            return await SendRequest<WrikeTask>($"tasks/{taskId}", HttpMethods.Delete);
        }

        /// <summary>
        /// Search among all tasks in all accounts
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="accountId">Search among all tasks in the account</param>
        /// <param name="folderId">Search among tasks in the folder</param>
        /// <param name="addDescendents">Adds all descendant folders to search scope</param>
        /// <param name="title">Title filter, exact match</param>
        /// <param name="status">Status filter, match with any of specified constants </param>
        /// <param name="importance">Importance filter, exact match </param>
        /// <param name="startDate">Start date filter, date match or range</param>
        /// <param name="dueDate">Due date filter, date match or range</param>
        /// <param name="scheduledDate">Scheduled date filter. Both dates should be set in ranged version. Returns all tasks
        /// that have schedule intersecting with specified interval, date match or range</param>
        /// <param name="createdDate">Created date filter, range</param>
        /// <param name="updatedDate">Updated date filter, range</param>
        /// <param name="completedDate">Completed date filter, range</param>
        /// <param name="authors">Authors filter, match of any</param>
        /// <param name="responsibles">Responsibles filter, match of any</param>
        /// <param name="shareds">Shared users filter, match of any</param>
        /// <param name="permalink">Task permalink, exact match</param>
        /// <param name="type">Task type </param>
        /// <param name="limit">Limit on number of returned tasks</param>
        /// <param name="sortField">Sort field </param>
        /// <param name="sortOrder">Sort order </param>
        /// <param name="addSubTasks">Adds subtasks to search scope</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="nextPageToken">Next page token, overrides any other parameters in request</param>
        /// <param name="metadata">Task metadata filter</param>
        /// <param name="customField">Custom field filter</param>
        /// <param name="customStatuses">Custom statuses filter</param>
        /// <param name="optionalFields">optional fields to be included in the response model 
        /// Use WrikeTask.OptionalFields values</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-tasks"/>
        public async Task<WrikeResDto<WrikeTask>> GetTasksAsync(
            string accountId = null,
            string folderId = null,
            bool? addDescendents = null,
            string title = null,
            WrikeTaskStatus? status = null,
            WrikeTaskImportance? importance = null,
            IWrikeDateFilter startDate = null,
            IWrikeDateFilter dueDate = null,
            IWrikeDateFilter scheduledDate = null,
            WrikeDateFilterRange createdDate = null,
            WrikeDateFilterRange updatedDate = null,
            WrikeDateFilterRange completedDate = null,
            List<string> authors = null,
            List<string> responsibles = null,
            List<string> shareds = null,
            string permalink = null,
            WrikeTaskDateType? type = null,
            int? limit = null,
            WrikeTaskSortField? sortField = null,
            WrikeSortOrder? sortOrder = null,
            bool? addSubTasks = null,
            int? pageSize = null,
            string nextPageToken = null,
            WrikeMetadata metadata = null,
            WrikeCustomFieldData customField = null,
            List<string> customStatuses = null,
            List<string> optionalFields = null
            )
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


        /// <summary>
        ///  Returns complete information about single or multiple tasks. 
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="taskIds">MaxCount 100</param>
        /// <param name="optionalFields">Use WrikeTask.OptionalFields values Only Recurrent and AttachmentCount supported</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-tasks"/>
        public async Task<WrikeResDto<WrikeTask>> GetTasksAsync(List<string> taskIds, List<string> optionalFields = null)
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
        #endregion

        #region Folders & Projects
        /// <summary>
        /// Returns complete information about specified folders
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="folderIds">MaxCount 100</param>
        /// <param name="optionalFields">Use WrikeFolder.OptionalFields values</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-folder"/>
        public async Task<WrikeResDto<WrikeFolder>> GetFoldersAsync(List<string> folderIds, List<string> optionalFields = null)
        {
            if (folderIds == null || folderIds.Count < 1)
            {
                throw new ArgumentNullException("folderIds can not be null or empty");
            }
            if (folderIds.Count > 100)
            {
                throw new ArgumentException("folderIds max count is 100");
            }

            var requestUri = "folders/" + string.Join(",", folderIds);

            if (optionalFields != null && optionalFields.Count > 0)
            {
                requestUri += "?fields=" + JsonConvert.SerializeObject(optionalFields);
            }

            return await SendRequest<WrikeFolder>(requestUri, HttpMethods.Get);
        }

        /// <summary>
        /// Returns a list of tree entries
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        ///<param name="accountId">Returns a list of tree entries for the account</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-folder-tree"/>
        public async Task<WrikeResDto<WrikeFolderTree>> GetFolderTreeAsync(string accountId = null)
        {
            if (accountId == null)
            {
                return await SendRequest<WrikeFolderTree>("folders", HttpMethods.Get);
            }

            return await SendRequest<WrikeFolderTree>($"accounts/{accountId}/folders", HttpMethods.Get);
        }
        #endregion

        #region CustomFields
        /// <summary>
        /// Returns a list of custom fields in all accessible accounts
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="accountId">If provided; returns a list of custom fields in particular account</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        public async Task<WrikeResDto<WrikeCustomField>> GetCustomFieldsAsync(string accountId = null)
        {
            var requestUri = $"customfields";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/customfields";
            }

            return await SendRequest<WrikeCustomField>(requestUri, HttpMethods.Get);
        }

        /// <summary>
        /// Returns complete information about specified custom fields
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="customFieldIds">string list of customFiledIds</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        public async Task<WrikeResDto<WrikeCustomField>> GetCustomFieldsAsync(List<string> customFieldIds)
        {
            if (customFieldIds == null || customFieldIds.Count < 1)
            {
                throw new ArgumentNullException("customFieldIds can not be null or empty");
            }
            if (customFieldIds.Count > 100)
            {
                throw new ArgumentException("customFieldIds max count is 100");
            }

            var customFieldsValue = string.Join(",", customFieldIds);
            return await SendRequest<WrikeCustomField>($"customfields/{customFieldsValue}", HttpMethods.Get);
        }

        /// <summary>
        /// Create custom field in specified account
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <remarks></remarks>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-custom-field"/>
        /// <param name="customField">AccountId, Title and Text values should be set</param>
        public async Task<WrikeResDto<WrikeCustomField>> CreateCustomFieldAsync(WrikeCustomField customField)
        {
            if (customField == null)
            {
                throw new ArgumentNullException("CustomField can not be null");
            }
            if (string.IsNullOrWhiteSpace(customField.AccountId))
            {
                throw new ArgumentNullException("customField.AccountId can not be null or empty");
            }

            var data = new List<KeyValuePair<string, string>>();

            data.Add(new KeyValuePair<string, string>("title", customField.Title));
            data.Add(new KeyValuePair<string, string>("type", customField.Type.ToString()));
            if (customField.SharedIds != null && customField.SharedIds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("shareds", JsonConvert.SerializeObject(customField.SharedIds)));
            }

            var postContent = new FormUrlEncodedContent(data);

            return await SendRequest<WrikeCustomField>($"accounts/{customField.AccountId}/customfields",
                HttpMethods.Post, postContent);
        }

        /// <summary>
        /// Updates custom field
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <remarks></remarks>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-custom-field"/>        
        public async Task<WrikeResDto<WrikeCustomField>> UpdateCustomFieldAsync(
            string id, string title = null, string type = null, List<string> addShareds = null, List<string> removeShareds = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null");
            }

            var data = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(title))
            {
                data.Add(new KeyValuePair<string, string>("title", title));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                data.Add(new KeyValuePair<string, string>("type", type));

            }
            if (addShareds != null && addShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("addShareds", JsonConvert.SerializeObject(addShareds)));
            }
            if (removeShareds != null && removeShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("removeShareds", JsonConvert.SerializeObject(removeShareds)));
            }

            var putContent = new FormUrlEncodedContent(data);

            return await SendRequest<WrikeCustomField>($"customfields/{id}", HttpMethods.Put, putContent);
        }
        #endregion

        #region Version
        /// <summary>
        /// Returns current API version info
        /// </summary>
        public async Task<WrikeResDto<WrikeVersion>> GetVersion()
        {
            return await SendRequest<WrikeVersion>("version", HttpMethods.Get);
        }
        #endregion

        #region Colors
        /// <summary>
        /// Get color name - code mapping
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-colors"/>
        public async Task<WrikeResDto<WrikeColor>> GetColorsAsync()
        {
            return await SendRequest<WrikeColor>("colors", HttpMethods.Get);
        }
        #endregion

        private async Task<WrikeResDto<T>> SendRequest<T>(
            string requestUri,
            string httpMethod,
            HttpContent httpContent = null)
        {
            HttpResponseMessage responseMessage = null;


            switch (httpMethod)
            {
                case HttpMethods.Get:
                    responseMessage = await _httpClient.GetAsync(requestUri);
                    break;
                case HttpMethods.Post:
                    responseMessage = await _httpClient.PostAsync(requestUri, httpContent);
                    break;
                case HttpMethods.Put:
                    responseMessage = await _httpClient.PutAsync(requestUri, httpContent);
                    break;
                case HttpMethods.Delete:
                    responseMessage = await _httpClient.DeleteAsync(requestUri);
                    break;
                default:
                    throw new ArgumentException("Unknown HTTP METHOD!");
            }
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<T>>(json);

            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }

            return wrikeResDto;
        }

        private class HttpMethods
        {
            public const string Get = "GET";
            public const string Post = "POST";
            public const string Put = "PUT";
            public const string Delete = "DELETE";
        }
    }
}

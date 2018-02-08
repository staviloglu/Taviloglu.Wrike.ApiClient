using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeTasksClient
    {
        /// <summary>
        ///  Create task in folder.  
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="folderId">You can specify rootFolderId to create task in user's account root.</param>
        /// <param name="newTask">use task constructor with parameters</param>
        /// <param name="priorityBefor">Put newly created task before specified task in task list</param>
        /// <param name="priorityAfter">Put newly created task after specified task in task list</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-task"/>
        Task<WrikeResDto<WrikeTask>> CreateAsync(string folderId, WrikeTask newTask, string priorityBefore = null, string priorityAfter=null);

        /// <summary>
        /// Delete task by Id
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-tasks"/>        
        Task<WrikeResDto<WrikeTask>> DeleteAsync(string taskId);

        /// <summary>
        /// Search among all tasks in all accounts
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="accountId">Search among all tasks in the account</param>
        /// <param name="folderId">Search among tasks in the folder</param>
        /// <param name="addDescendants">Adds all descendant folders to search scope</param>
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
        /// <param name="fields">optional fields to be included in the response model 
        /// Use WrikeTask.OptionalFields values</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-tasks"/>
        Task<WrikeResDto<WrikeTask>> GetAsync(
            string accountId = null,
            string folderId = null,
            bool? addDescendants = null,
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
            List<string> fields = null
            );


        /// <summary>
        ///  Returns complete information about single or multiple tasks. 
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="taskIds">MaxCount 100</param>
        /// <param name="optionalFields">Use WrikeTask.OptionalFields values Only Recurrent and AttachmentCount supported</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-tasks"/>
        Task<WrikeResDto<WrikeTask>> GetAsync(List<string> taskIds, List<string> optionalFields = null);
    }
}

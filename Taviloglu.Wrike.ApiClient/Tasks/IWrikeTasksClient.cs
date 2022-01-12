using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.Tasks;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Task operations
    /// </summary>
    public interface IWrikeTasksClient
    {
        /// <summary>
        /// This parameter is set by your last GetAsync method call if you use pageSize parameter to have paged response
        /// Use this property as nextPageToken parameter of GetAsync method to get the next page of the paged response
        /// </summary>
        string LastNextPageToken { get; }
        /// <summary>
        /// This parameter is set by your last GetAsync method call if you use pageSize parameter to have paged response
        /// </summary>
        int LastResponseSize { get; }

        /// <summary>
        ///  Create task in folder.  
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <remarks>If newTask.CustomStatus is set, newTask.Status is ommited</remarks>
        /// <param name="folderId">You can specify rootFolderId to create task in user's account root.</param>
        /// <param name="newTask"></param>
        /// <param name="priorityBefore">Put newly created task before specified task in task list</param>
        /// <param name="priorityAfter">Put newly created task after specified task in task list</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-task"/>
        Task<WrikeTask> CreateAsync(WrikeClientIdParameter folderId, WrikeTask newTask, string priorityBefore = null, string priorityAfter = null);

        /// <summary>
        /// Delete task by Id
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-tasks"/>        
        Task<WrikeTask> DeleteAsync(WrikeClientIdParameter taskId);

        /// <summary>
        /// Search among all tasks in the account.
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
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
        /// Use <see cref="WrikeTask.OptionalFields"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-tasks"/>
        Task<List<WrikeTask>> GetAsync(
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
            List<string> fields = null);


        /// <summary>
        ///  Returns complete information about single or multiple tasks. 
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="taskIds">Task Ids</param>
        /// <param name="optionalFields">Use <see cref="WrikeTask.OptionalFields"/> values Only Recurrent and AttachmentCount supported</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-tasks"/>
        Task<List<WrikeTask>> GetAsync(WrikeClientIdListParameter taskIds, List<string> optionalFields = null);

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="title">Title of task</param>
        /// <param name="description">Task Description</param>
        /// <param name="status">Task status </param>
        /// <param name="importance">Task importance </param>
        /// <param name="dates">Reschedule task and/or change task type</param>
        /// <param name="addParents">Put task into specified folders of same account. Cannot contain RecycleBin folder</param>
        /// <param name="removeParents">Remove task from specified folders. Can not contain RecycleBin folder</param>
        /// <param name="addShareds">Shared task with specified users</param>
        /// <param name="removeShareds">Unshare task from specified users</param>
        /// <param name="addResponsibles">Add specified users to responsible list</param>
        /// <param name="removeResponsibles">Remove specified users from responsible list</param>
        /// <param name="addFollowers">Add specified users to follow task</param>        
        /// <param name="follow">Add specified users to task followers</param>
        /// <param name="priorityBefore">Put task in task list before specified task</param>
        /// <param name="priorityAfter">Put task in task list after specified task</param>
        /// <param name="addSuperTasks">Add the task as subtask to specified tasks</param>
        /// <param name="removeSuperTasks">Remove the task form specified tasks subtasks</param>
        /// <param name="metadata">Metadata to be updated (null value removes entry)</param>
        /// <param name="customFields">Custom fields to be updated or deleted (null value removes field) Use <see cref="WrikeTask.OptionalFields"/></param>
        /// <param name="customStatus">Custom status ID</param>
        /// <param name="effortAllocation">Task Effort allocation</param>
        /// <param name="restore">Restore task from Recycled Bin</param>
        /// <returns></returns>
        Task<WrikeTask> UpdateAsync(WrikeClientIdParameter taskId,
            string title = null,
            string description = null,
            WrikeTaskStatus? status = null,
            WrikeTaskImportance? importance = null,
            WrikeTaskDate dates = null,
            List<string> addParents = null,
            List<string> removeParents = null,
            List<string> addShareds = null,
            List<string> removeShareds = null,
            List<string> addResponsibles = null,
            List<string> removeResponsibles = null,
            List<string> addFollowers = null,
            bool? follow = null,
            string priorityBefore = null,
            string priorityAfter = null,
            List<string> addSuperTasks = null,
            List<string> removeSuperTasks = null,
            List<WrikeMetadata> metadata = null,
            List<WrikeCustomFieldData> customFields = null,
            string customStatus = null,
            WrikeTaskEffortAllocation effortAllocation = null,
            bool? restore = null);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Timelogs;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Timelog operations
    /// </summary>
    public interface IWrikeTimelogsClient
    {
        /// <summary>
        /// Create timelog record for task
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="newTimeLog"></param>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-timelog"/>
        Task<WrikeTimelog> CreateAsync(WrikeTimelog newTimeLog, bool? plainText = null);

        /// <summary>
        /// Update timelog by Id
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="timelogId"></param>
        /// <param name="comment">Timelog comment</param>
        /// <param name="hours">New timelog tracked hours</param>
        /// <param name="trackedDate">New timelog date </param>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise</param>
        /// <param name="categoryId">Timelog category</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/modify-timelog"/>
        Task<WrikeTimelog> UpdateAsync(string timelogId, string comment = null, int? hours = null, DateTime? trackedDate = null, bool? plainText = null, string categoryId = null);

        /// <summary>
        /// Delete Timelog record by ID
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-timelog"/>        
        Task DeleteAsync(string timelogId);

        /// <summary>
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="contactId">Get all timelog records that were created by the user.</param>        
        /// <param name="folderId">Get all timelog records for a folder.</param>
        /// <param name="taskId">Get all timelog records for a task.</param>
        /// <param name="categoryId"> Get all timelog records with specific timelog category.</param>
        /// <param name="createdDate">Created date filter, exact match or range</param>
        /// <param name="trackedDate">Tracked date filter, exact match or range</param>
        /// <param name="me">If present - only timelogs created by current user are returned</param>
        /// <param name="descendants">Adds all descendant tasks to search scope</param>
        /// <param name="subTasks">Adds subtasks to search scope</param>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise.</param>
        /// <param name="categories">Get timelog records for specified categories</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-timelogs"/>        
        Task<List<WrikeTimelog>> GetAsync(
            string contactId = null,
            string folderId = null,
            string taskId = null,
            string categoryId = null,
            WrikeDateFilterRange createdDate = null,
            IWrikeDateFilter trackedDate = null,
            bool? me = null,
            bool? descendants = null,
            bool? subTasks = null,
            bool? plainText = null,
            List<string> categories = null);

        /// <summary>
        ///  Get timelog record by ID. 
        ///  Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="id">TimelogId</param>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/query-timelogs"/>
        Task<WrikeTimelog> GetAsync(string id, bool? plainText = null);
    }
}

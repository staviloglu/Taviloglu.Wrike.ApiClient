using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public interface IWrikeCommentsClient
    {
        /// <summary>
        /// Get all comments in all accounts. 
        /// Scopes: Default, wsReadOnly, wsReadWrite
        /// </summary>
        /// <param name="folderId"> Get folder comments.</param>
        /// /// <param name="taskId"> Get task comments.</param>
        /// <param name="limit">Maximum number of returned comments, Default:1000</param>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise, Default: false</param>
        /// <param name="updatedDate">Updated date filter, get all comments created or updated in the range specified by dates. Time range between dates must be less than 7 days</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/get-comments"/>
        Task<List<WrikeComment>> GetAsync(string folderId = null, string taskId = null, bool? plainText = null, int? limit = null, WrikeDateFilterRange updatedDate = null);

        /// <summary>
        /// Get single or multiple comments by their IDs.
        /// </summary>
        /// <param name="commentIds"></param>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise, Default: false</param>
        /// <returns></returns>
        Task<List<WrikeComment>> GetAsync(List<string> commentIds, bool? plainText = null);

        /// <summary>
        /// Delete comment by ID.
        /// Scopes: Default, wsReadWrite
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/delete-comment"/>        
        Task DeleteAsync(string commentId);

        /// <summary>
        ///  Update Comment by ID. A comment is available for updates only during the 5 minutes after creation.
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="plainText">Get comment text as plain text, HTML otherwise, Default: false</param>
        /// <param name="text">Comment text, can not be empty</param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/update-comment"/>
        Task<WrikeComment> UpdateAsync(string id, string text, bool? plainText = null);

        /// <summary>
        ///  Create a comment in the folder/task. The virtual Root and Recycle Bin folders cannot have comments.
        ///  Scopes: Default, wsReadWrite
        /// </summary>
        /// <param name="plainText">Treat comment text as plain text, HTML otherwise</param>
        /// <param name="newComment">Use ctor <see cref="WrikeComment.WrikeComment(string, string, string)"/></param>
        /// See <see href="https://developers.wrike.com/documentation/api/methods/create-comment"/>
        Task<WrikeComment> CreateAsync(WrikeComment newComment, bool? plainText = null);

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeCommentsClient
    {
        public IWrikeCommentsClient Comments
        {
            get
            {
                return (IWrikeCommentsClient)this;
            }
        }

        async Task<WrikeComment> IWrikeCommentsClient.CreateAsync(WrikeComment newComment, bool? plainText)
        {
            if (newComment == null)
            {
                throw new ArgumentNullException(nameof(newComment));
            }

            var requestUri = string.Empty;

            if (!string.IsNullOrWhiteSpace(newComment.TaskId))
            {
                requestUri = $"tasks/{newComment.TaskId}/comments";
            }
            else if (!string.IsNullOrWhiteSpace(newComment.FolderId))
            {
                requestUri = $"folders/{newComment.FolderId}/comments";
            }
            else
            {
                throw new ArgumentNullException("one of newComment.TaskId or newComment.FolderId should be set. Do not use empty ctor");
            }

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("plainText", plainText)
                .AddParameter("text", newComment.Text);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeComment>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        async Task IWrikeCommentsClient.DeleteAsync(string commentId)
        {
            if (commentId == null)
            {
                throw new ArgumentNullException(nameof(commentId));
            }

            if (commentId.Trim() == string.Empty)
            {
                throw new ArgumentException("commentId can not be empty", nameof(commentId));
            }

            await SendRequest<WrikeComment>($"comments/{commentId}", HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(string folderId, string taskId, bool? plainText, int? limit, WrikeDateFilterRange updatedDate)
        {
            var requestUri = "comments";

            if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = $"folders/{folderId}/comments";
            }
            else if (!string.IsNullOrWhiteSpace(taskId))
            {
                requestUri = $"tasks/{taskId}/comments";
            }

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("plainText", plainText)
                .AddParameter("updatedDate", updatedDate)
                .AddParameter("limit", limit);


            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(List<string> commentIds, bool? plainText)
        {
            if (commentIds == null)
            {
                throw new ArgumentNullException(nameof(commentIds));
            }

            if (commentIds.Count == 0)
            {
                throw new ArgumentException("commentIds can not be empty", nameof(commentIds));
            }

            if (commentIds.Count > 100)
            {
                throw new ArgumentException("Max. 100 commentIds can be used", nameof(commentIds));
            }

            var requestUri = "comments/";
            var commentIdsValue = string.Join(",", commentIds);
            requestUri = requestUri + commentIdsValue;
            var uriBuilder = new WrikeGetUriBuilder(requestUri).AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeComment> IWrikeCommentsClient.UpdateAsync(string id, string text, bool? plainText)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException("id can not be empty", nameof(id));
            }

            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text.Trim() == string.Empty)
            {
                throw new ArgumentException("text can not be empty", nameof(text));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("text", text)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>($"comments/{id}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

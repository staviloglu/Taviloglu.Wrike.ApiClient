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
                throw new ArgumentNullException(nameof(newComment), "newComment can not be null, do not use empty ctor");
            }

            if (string.IsNullOrWhiteSpace(newComment.Text))
            {
                throw new ArgumentNullException(nameof(newComment.Text), "newComment.Text can not be null or empty");
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

            if (string.IsNullOrWhiteSpace(commentId))
            {
                throw new ArgumentNullException(nameof(commentId), "commentId can not be null or empty");
            }

            await SendRequest<WrikeTask>($"comments/{commentId}", HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(string accountId, string folderId, string taskId, bool? plainText, int? limit, WrikeDateFilterRange updatedDate)
        {
            var requestUri = "comments";

            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = @"accounts/{accountId}/comments";
            }
            else if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = @"folders/{folderId}/comments";
            }
            else if (!string.IsNullOrWhiteSpace(taskId))
            {
                requestUri = @"tasks/{taskId}/comments";
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
            if (commentIds == null || commentIds.Count < 1)
            {
                throw new ArgumentException("commentIds can not be null or empty!", nameof(commentIds));
            }
            if (commentIds.Count > 100)
            {
                throw new ArgumentException("commentIds max count is 100");
            }

            var requestUri = "comments/";
            var commentIdsValue = string.Join(",", commentIds);
            requestUri = requestUri + commentIdsValue;
            var uriBuilder = new WrikeGetUriBuilder(requestUri).AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeComment> IWrikeCommentsClient.UpdateAsync(string commentId, string text, bool? plainText)
        {
            if (string.IsNullOrWhiteSpace(commentId))
            {
                throw new ArgumentNullException(nameof(commentId), "commentId can not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "text can not be null or empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("text", text)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>($"comments/{commentId}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

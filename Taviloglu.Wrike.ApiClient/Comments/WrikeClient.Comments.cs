using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;

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

        async Task<T> IWrikeCommentsClient.CreateAsync<T>(T newComment, bool? plainText) 
        {
            if (newComment == null)
            {
                throw new ArgumentNullException(nameof(newComment));
            }

            var requestUri = string.Empty;

            if (newComment is WrikeTaskComment)
            {
                requestUri = $"tasks/{(newComment as WrikeTaskComment).TaskId}/comments";
            }
            else
            {
                //newComment is WrikeFolderComment
                requestUri = $"folders/{(newComment as WrikeFolderComment).FolderId}/comments";
            }

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("plainText", plainText)
                .AddParameter("text", newComment.Text);

            var postContent = postDataBuilder.GetContent();

            var response = await SendRequest<T>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
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
                throw new ArgumentException("value can not be empty", nameof(commentId));
            }

            await SendRequest<WrikeComment>($"comments/{commentId}", HttpMethods.Delete).ConfigureAwait(false);
        }

        async Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(bool? plainText, int? limit, WrikeDateFilterRange updatedDate)
        {
            var requestUri = "comments";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("plainText", plainText)
                .AddParameter("limit", limit)
                .AddParameter("udatedDate", updatedDate);

            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get, jsonConverter: new WrikeCommentConverter()).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeFolderComment>> IWrikeCommentsClient.GetInFolderAsync(string folderId, bool? plainText)
        {
            if (folderId == null)
            {
                throw new ArgumentNullException(nameof(folderId));
            }

            if (folderId.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(folderId));
            }


            var requestUri = $"folders/{folderId}/comments";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeFolderComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeTaskComment>> IWrikeCommentsClient.GetInTaskAsync(string taskId, bool? plainText)
        {
            if (taskId == null)
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            if (taskId.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(taskId));
            }

            var requestUri = $"tasks/{taskId}/comments";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeTaskComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
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
                throw new ArgumentException("value can not be empty", nameof(commentIds));
            }

            if (commentIds.Count > 100)
            {
                throw new ArgumentException("Max. 100 commentIds can be used", nameof(commentIds));
            }

            var requestUri = "comments/";
            var commentIdsValue = string.Join(",", commentIds);
            requestUri = requestUri + commentIdsValue;
            var uriBuilder = new WrikeGetUriBuilder(requestUri).AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get, jsonConverter:new WrikeCommentConverter()).ConfigureAwait(false);
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
                throw new ArgumentException("value can not be empty", nameof(id));
            }

            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(text));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("text", text)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>($"comments/{id}", HttpMethods.Put, 
                contentBuilder.GetContent(), new WrikeCommentConverter()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Comments;
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

        async Task IWrikeCommentsClient.DeleteAsync(WrikeClientIdParameter id)
        {
            await SendRequest<WrikeComment>($"comments/{id}", HttpMethods.Delete, jsonConverter: new WrikeCommentConverter()).ConfigureAwait(false);
        }

        async Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(bool? plainText, int? limit, WrikeDateFilterRange updatedDate)
        {
            var requestUri = "comments";

            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("plainText", plainText)
                .AddParameter("limit", limit)
                .AddParameter("udatedDate", updatedDate);

            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get, jsonConverter: new WrikeCommentConverter()).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeFolderComment>> IWrikeCommentsClient.GetInFolderAsync(WrikeClientIdParameter folderId, bool? plainText)
        {
            var requestUri = $"folders/{folderId}/comments";

            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeFolderComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeTaskComment>> IWrikeCommentsClient.GetInTaskAsync(WrikeClientIdParameter taskId, bool? plainText)
        {
            var requestUri = $"tasks/{taskId}/comments";

            var uriBuilder = new WrikeUriBuilder(requestUri)
                .AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeTaskComment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeComment>> IWrikeCommentsClient.GetAsync(WrikeClientIdListParameter commentIds, bool? plainText)
        {
            var requestUri = $"comments/{commentIds}";
            var uriBuilder = new WrikeUriBuilder(requestUri).AddParameter("plainText", plainText);

            var response = await SendRequest<WrikeComment>(uriBuilder.GetUri(), HttpMethods.Get, jsonConverter:new WrikeCommentConverter()).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeComment> IWrikeCommentsClient.UpdateAsync(WrikeClientIdParameter id, string text, bool? plainText)
        {
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

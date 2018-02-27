using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeAttachmentsClient
    {
        public IWrikeAttachmentsClient Attachments
        {
            get
            {
                return (IWrikeAttachmentsClient)this;
                //throw new NotImplementedException("Attachments not implemented yet!");
            }
        }

        public async Task<List<WrikeAttachment>> GetAsync(string accountId, string folderId,string taskId, bool? versions = null, WrikeDateFilterRange createdDate = null, bool? withUrls = null)
        {
            if ((!string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(folderId)) 
                || (!string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(taskId)) 
                || (!string.IsNullOrWhiteSpace(folderId) && !string.IsNullOrWhiteSpace(taskId))
                )
            {
                throw new ArgumentException("only folderId or accountId or taskId can be used, not all of them!");
            }
            if (string.IsNullOrWhiteSpace(accountId) && string.IsNullOrWhiteSpace(folderId) && string.IsNullOrWhiteSpace(taskId))
            {
                throw new ArgumentException("one of folderId, accountId or taskId should be used");
            }
            var requestUri = "attachments";

            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/attachments";
            }
            else if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = $"folders/{folderId}/attachments";
            }
            else if (!string.IsNullOrWhiteSpace(taskId))
            {
                requestUri = $"tasks/{taskId}/attachments";
            }

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
            .AddParameter("versions", versions)
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("withUrls", withUrls);
            

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        public async Task<WrikeAttachment> GetAsync(string attachmentId, bool? versions = null)
        {
            if (string.IsNullOrWhiteSpace(attachmentId))
            {
                throw new ArgumentException("you need to provide attachmen id to get the attachment information!");
            }

            var requestUri = $"attachments/{attachmentId}/";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
           .AddParameter("versions", versions);

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        public async Task<Stream> GetAsync(string attachmentId)
        {
            if (string.IsNullOrWhiteSpace(attachmentId))
            {
                throw new ArgumentException("you need to provide attachmen id to download attachment!");
            }
            var requestUri = $"attachments/{attachmentId}/download";

            var uriBuilder = new WrikeGetUriBuilder(requestUri);

            var response = await SendRequestAndGetStream<Stream>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);

            return response;
        }

        public async Task<Stream> GetAsync(string attachmentId, WrikePreviewDimension? size)
        {
            if (string.IsNullOrWhiteSpace(attachmentId))
            {
                throw new ArgumentException("you need to provide attachmen id to preview attachment!");
            }
            var requestUri = $"attachments/{attachmentId}/preview";

            var uriBuilder = new WrikeGetUriBuilder(requestUri);

            var response = await SendRequestAndGetStream<Stream>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);

            return response;
        }
        
    }
}

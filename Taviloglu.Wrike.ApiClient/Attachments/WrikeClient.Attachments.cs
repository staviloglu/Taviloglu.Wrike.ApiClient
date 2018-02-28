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
            }
        }

        async Task<List<WrikeAttachment>> IWrikeAttachmentsClient.GetAsync(string accountId, string folderId,string taskId, bool? versions, WrikeDateFilterRange createdDate, bool? withUrls)
        {
            int notNullCount = 0;
            var requestUri = string.Empty;

            if (!string.IsNullOrWhiteSpace(accountId))
            {
                notNullCount++;
                requestUri = $"accounts/{accountId}/attachments";
            }

            if (!string.IsNullOrWhiteSpace(folderId))
            {
                notNullCount++;
                requestUri = $"folders/{folderId}/attachments";
            }
            if (!string.IsNullOrWhiteSpace(taskId))
            {
                notNullCount++;
                requestUri = $"tasks/{taskId}/attachments";
            }

            if (notNullCount!=1) throw new ArgumentException("one and only one of folderId, accountId or taskId should be used");
            
            var uriBuilder = new WrikeGetUriBuilder(requestUri)
            .AddParameter("versions", versions)
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("withUrls", withUrls);
            

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeAttachment> IWrikeAttachmentsClient.GetAsync(string attachmentId, bool? versions)
        {
            if (string.IsNullOrWhiteSpace(attachmentId))
            {
                throw new ArgumentException(nameof(attachmentId));
            }

            var requestUri = $"attachments/{attachmentId}/";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
           .AddParameter("versions", versions);

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        async Task<Stream> IWrikeAttachmentsClient.DownloadAsync(string attachmentId)
        {
            if (string.IsNullOrWhiteSpace(attachmentId))
            {
                throw new ArgumentException(nameof(attachmentId));
            }
            var response = await SendRequestAndGetStream<Stream>($"attachments/{attachmentId}/download", HttpMethods.Get).ConfigureAwait(false);

            return response;
        }

        async Task<Stream> IWrikeAttachmentsClient.DownloadPreviewAsync(string attachmentId, WrikePreviewDimension? size)
        {
            if (string.IsNullOrWhiteSpace(attachmentId))
            {
                throw new ArgumentException(nameof(attachmentId));
            }

            var response = await SendRequestAndGetStream<Stream>($"attachments/{attachmentId}/preview", HttpMethods.Get).ConfigureAwait(false);

            return response;
        }        
    }
}

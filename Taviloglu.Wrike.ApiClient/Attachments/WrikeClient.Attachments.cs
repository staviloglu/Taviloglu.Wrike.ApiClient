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

        async Task<List<WrikeAttachment>> IWrikeAttachmentsClient.GetAsync(string folderId,string taskId, bool? versions, WrikeDateFilterRange createdDate, bool? withUrls)
        {
            if (!string.IsNullOrWhiteSpace(taskId) && !string.IsNullOrWhiteSpace(folderId))
            {
                throw new ArgumentException("taskId or folderId can be used, not both!");
            }

            if (string.IsNullOrWhiteSpace(taskId) && string.IsNullOrWhiteSpace(folderId))
            {
                throw new ArgumentException("taskId or folderId should be used!");
            }

            var requestUri = string.Empty;            

            if (!string.IsNullOrWhiteSpace(folderId))
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

        async Task<WrikeAttachment> IWrikeAttachmentsClient.GetAsync(string id, bool? versions)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException("id can not be empty", nameof(id));
            }

            var requestUri = $"attachments/{id}/";

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
           .AddParameter("versions", versions);

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        async Task<Stream> IWrikeAttachmentsClient.DownloadAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException("id can not be empty", nameof(id));
            }

            var response = await SendRequestAndGetStream<Stream>($"attachments/{id}/download", HttpMethods.Get).ConfigureAwait(false);

            return response;
        }

        async Task<Stream> IWrikeAttachmentsClient.DownloadPreviewAsync(string id, WrikePreviewDimension? size)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException("id can not be empty", nameof(id));
            }

            var response = await SendRequestAndGetStream<Stream>($"attachments/{id}/preview", HttpMethods.Get).ConfigureAwait(false);

            return response;
        }        
    }
}

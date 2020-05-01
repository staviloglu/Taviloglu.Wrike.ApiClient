using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Attachments;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeAttachmentsClient
    {
        public IWrikeAttachmentsClient Attachments { get { return (IWrikeAttachmentsClient)this; } }

        async Task<List<WrikeAttachment>> IWrikeAttachmentsClient.GetAsync(bool? versions, WrikeDateFilterRange createdDate, bool? withUrls)
        {
            var uriBuilder = new WrikeUriBuilder($"attachments")
            .AddParameter("versions", versions)
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("withUrls", withUrls);

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get, jsonConverter: new WrikeAttachmentConverter()).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeFolderAttachment>> IWrikeAttachmentsClient.GetInFolderAsync(WrikeClientIdParameter folderId, bool? versions, WrikeDateFilterRange createdDate, bool? withUrls)
        {
            var uriBuilder = new WrikeUriBuilder($"folders/{folderId}/attachments")
            .AddParameter("versions", versions)
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("withUrls", withUrls);

            var response = await SendRequest<WrikeFolderAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeTaskAttachment>> IWrikeAttachmentsClient.GetInTaskAsync(WrikeClientIdParameter taskId, bool? versions, WrikeDateFilterRange createdDate, bool? withUrls)
        {
            var uriBuilder = new WrikeUriBuilder($"tasks/{taskId}/attachments")
            .AddParameter("versions", versions)
            .AddParameter("createdDate", createdDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("withUrls", withUrls);

            var response = await SendRequest<WrikeTaskAttachment>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeAttachment>> IWrikeAttachmentsClient.GetAsync(WrikeClientIdListParameter ids, bool? versions)
        {
            var uriBuilder = new WrikeUriBuilder($"attachments/{ids}")
           .AddParameter("versions", versions);

            var response = await SendRequest<WrikeAttachment>(uriBuilder.GetUri(), HttpMethods.Get, jsonConverter: new WrikeAttachmentConverter()).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<Stream> IWrikeAttachmentsClient.DownloadAsync(WrikeClientIdParameter id)
        {
            var response = await SendRequestAndGetStream<Stream>($"attachments/{id}/download", HttpMethods.Get).ConfigureAwait(false);

            return response;
        }

        async Task<Stream> IWrikeAttachmentsClient.DownloadPreviewAsync(WrikeClientIdParameter id, WrikePreviewDimension? size)
        {
            var uriBuilder = new WrikeUriBuilder($"attachments/{id}/preview")
                .AddParameter("size", size);

            var response = await SendRequestAndGetStream<Stream>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);

            return response;
        }

        async Task IWrikeAttachmentsClient.DeleteAsync(WrikeClientIdParameter id)
        {
            await SendRequest<WrikeAttachment>($"attachments/{id}", HttpMethods.Delete, jsonConverter: new WrikeAttachmentConverter()).ConfigureAwait(false);
        }

        async Task<WrikeTaskAttachment> IWrikeAttachmentsClient.CreateInTaskAsync(WrikeClientIdParameter taskId, string fileName, byte[] fileBytes)
        {
            var response = await PostFile<WrikeTaskAttachment>($"tasks/{taskId}/attachments", fileName, fileBytes)
                .ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeFolderAttachment> IWrikeAttachmentsClient.CreateInFolderAsync(WrikeClientIdParameter folderId, string fileName, byte[] fileBytes)
        {
            var response = await PostFile<WrikeFolderAttachment>($"folders/{folderId}/attachments", fileName, fileBytes)
                .ConfigureAwait(false);
            return GetReponseDataFirstItem(response);

        }

        async Task<WrikeAttachmentUrl> IWrikeAttachmentsClient.GetAccessUrlAsync(WrikeClientIdParameter id)
        {
            var response = await SendRequest<WrikeAttachmentUrl>($"attachments/{id}/url", HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

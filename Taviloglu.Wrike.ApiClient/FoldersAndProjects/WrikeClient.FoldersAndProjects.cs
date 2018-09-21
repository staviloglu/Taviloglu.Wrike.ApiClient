using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.FoldersAndProjects;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.ApiClient
{
    public partial class WrikeClient : IWrikeFoldersAndProjectsClient
    {
        public IWrikeFoldersAndProjectsClient FoldersAndProjects
        {
            get
            {
                return (IWrikeFoldersAndProjectsClient)this;
            }
        }
        async Task<List<WrikeFolder>> IWrikeFoldersAndProjectsClient.GetFoldersAsync(List<string> folderIds, List<string> optionalFields)
        {
            if (folderIds == null)
            {
                throw new ArgumentNullException(nameof(folderIds));
            }

            if (folderIds.Count == 0)
            {
                throw new ArgumentException("folderIds can not be empty", nameof(folderIds));
            }

            if (folderIds.Count > 100)
            {
                throw new ArgumentException("Max. 100 folderIds can be used", nameof(folderIds));
            }

            var requestUri = "folders/" + string.Join(",", folderIds);

            if (optionalFields != null && optionalFields.Count > 0)
            {
                requestUri += "?fields=" + JsonConvert.SerializeObject(optionalFields);
            }

            var response = await SendRequest<WrikeFolder>(requestUri, HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeFolderTree>> IWrikeFoldersAndProjectsClient.GetFolderTreeAsync(string folderId, string permalink, bool? addDescendants, WrikeMetadata metadata, WrikeCustomFieldData customField, WrikeDateFilterRange updatedDate, bool? isProject, bool? isDeleted, List<string> fields)
        {
            var requestUri = "folders";

            bool useFolderId = !string.IsNullOrWhiteSpace(folderId);

            if (useFolderId)
            {
                requestUri = $"folders/{folderId}/folders";
            }

            var uriBuilder = new WrikeGetUriBuilder(requestUri)
            .AddParameter("permalink", permalink)
            .AddParameter("descendants", addDescendants)
            .AddParameter("metadata", metadata)
            .AddParameter("customField", customField)
            .AddParameter("updatedDate", updatedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("project", isProject)
            .AddParameter("fields", fields);

            if (!useFolderId)
            {
                uriBuilder.AddParameter("deleted", isDeleted);
            }

            var response = await SendRequest<WrikeFolderTree>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.CreateAsync(string folderId, WrikeFolder newFolder)
        {
            if (folderId == null)
            {
                throw new ArgumentNullException(nameof(folderId));
            }

            if (folderId.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(folderId), "folderId can not be empty");
            }

            if (newFolder == null)
            {
                throw new ArgumentNullException(nameof(newFolder));
            }

            var requestUri = $"folders/{folderId}/folders";

            var postDataBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", newFolder.Title)
                .AddParameter("description", newFolder.Description)
                .AddParameter("shareds", newFolder.SharedIds)
                .AddParameter("metadata", newFolder.Metadata)
                .AddParameter("customFields", newFolder.CustomFields)
                .AddParameter("customColumns", newFolder.CustomColumnIds)
                .AddParameter("project", newFolder.Project);

            var postContent = postDataBuilder.GetContent();
            var response = await SendRequest<WrikeFolder>(requestUri, HttpMethods.Post, postContent).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.DeleteAsync(string folderId)
        {
            if (folderId == null)
            {
                throw new ArgumentNullException(nameof(folderId));
            }

            if (folderId.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(folderId), "folderId can not be empty");
            }

            var response = await SendRequest<WrikeFolder>($"folders/{folderId} ", HttpMethods.Delete).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.UpdateAsync(string folderId, string title, string description, List<string> addParents, List<string> removeParents, List<string> addShareds, List<string> removeShareds, List<WrikeMetadata> metadata, bool? restore, List<WrikeCustomFieldData> customFields, List<string> customColumns, WrikeProject project)
        {
            if (folderId == null)
            {
                throw new ArgumentNullException(nameof(folderId));
            }

            if (folderId.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(folderId), "folderId can not be empty");
            }

            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (title.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(title), "title can not be empty");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", title)
                .AddParameter("description", description)
                .AddParameter("addParents", addParents)
                .AddParameter("removeParents", removeParents)
                .AddParameter("addShareds", addShareds)
                .AddParameter("removeShareds", removeShareds)
                .AddParameter("metadata", metadata)
                .AddParameter("restore", restore)
                .AddParameter("customFields", customFields)
                .AddParameter("customColumns", customColumns)
                .AddParameter("project", project);

            var response = await SendRequest<WrikeFolder>($"folders/{folderId}", HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        Task<WrikeFolder> IWrikeFoldersAndProjectsClient.CopyAsync(string parentFolderId, string title, string titlePrefix, bool? copyDescriptions, bool? copyResponsibles, List<string> addResponsibles, List<string> removeResponsibles, bool copyCustomFields, bool copyCustomStatuses, bool copyStatuses, bool copyParents, DateTime? rescheduleDate, FolderRescheduleMode? rescheduleMode, int entryLimit)
        {
            throw new NotImplementedException();
        }
    }
}

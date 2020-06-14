using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.FoldersAndProjects;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.CustomFields;
using Taviloglu.Wrike.Core.FoldersAndProjects;
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
        async Task<List<WrikeFolder>> IWrikeFoldersAndProjectsClient.GetFoldersAsync(WrikeClientIdListParameter folderIds, List<string> optionalFields)
        {
            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeFolder.OptionalFields.List).Any())
            {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeFolder.OptionalFields");
            }

            var uriBuilder = new WrikeUriBuilder($"folders/{folderIds}")
                .AddParameter("fields", optionalFields);

            var response = await SendRequest<WrikeFolder>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<List<WrikeFolderTree>> IWrikeFoldersAndProjectsClient.GetFolderTreeAsync(string folderId, string permalink, bool? addDescendants, WrikeMetadata metadata, WrikeCustomFieldData customField, WrikeDateFilterRange updatedDate, bool? isProject, bool? isDeleted, List<string> optionalFields)
        {

            if (optionalFields != null && optionalFields.Count > 0 && optionalFields.Except(WrikeFolderTree.OptionalFields.List).Any())
            {
                throw new ArgumentOutOfRangeException(nameof(optionalFields), "Use only values in WrikeFolderTree.OptionalFields");
            }

            var requestUri = "folders";

            bool useFolderId = !string.IsNullOrWhiteSpace(folderId);

            if (useFolderId)
            {
                requestUri = $"folders/{folderId}/folders";
            }

            var uriBuilder = new WrikeUriBuilder(requestUri)
            .AddParameter("permalink", permalink)
            .AddParameter("descendants", addDescendants)
            .AddParameter("metadata", metadata)
            .AddParameter("customField", customField)
            .AddParameter("updatedDate", updatedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"))
            .AddParameter("project", isProject)
            .AddParameter("deleted", isDeleted)
            .AddParameter("fields", optionalFields);

            if (!useFolderId)
            {
                uriBuilder.AddParameter("deleted", isDeleted);
            }

            var response = await SendRequest<WrikeFolderTree>(uriBuilder.GetUri(), HttpMethods.Get).ConfigureAwait(false);
            return GetReponseDataList(response);
        }

        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.CreateAsync(WrikeClientIdParameter folderId, WrikeFolder newFolder)
        {
            if (newFolder == null)
            {
                throw new ArgumentNullException(nameof(newFolder));
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("title", newFolder.Title)
                .AddParameter("description", newFolder.Description)
                .AddParameter("shareds", newFolder.SharedIds)
                .AddParameter("metadata", newFolder.Metadata)
                .AddParameter("customFields", newFolder.CustomFields)
                .AddParameter("customColumns", newFolder.CustomColumnIds)
                .AddParameter("project", newFolder.Project);

            var response = await SendRequest<WrikeFolder>($"folders/{folderId}/folders", HttpMethods.Post, contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.CopyAsync(WrikeClientIdParameter folderId, WrikeClientIdParameter parentFolderId, string title, string titlePrefix, bool? copyDescriptions, bool? copyResponsibles, List<string> addResponsibles, List<string> removeResponsibles, bool copyCustomFields, bool copyCustomStatuses, bool copyStatuses, bool copyParents, DateTime? rescheduleDate, FolderRescheduleMode? rescheduleMode, int entryLimit)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (title.Trim() == string.Empty)
            {
                throw new ArgumentException("title can not be empty", nameof(title));
            }

            if (entryLimit < 1 || entryLimit > 250)
            {
                throw new ArgumentOutOfRangeException(nameof(entryLimit), "value must be in [1,250] range");
            }

            var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
                .AddParameter("parent", parentFolderId)
                .AddParameter("title", title)
                .AddParameter("titlePrefix", titlePrefix)
                .AddParameter("copyDescriptions", copyDescriptions)
                .AddParameter("copyResponsibles", copyResponsibles)
                .AddParameter("addResponsibles", addResponsibles)
                .AddParameter("removeResponsibles", removeResponsibles)
                .AddParameter("copyCustomFields", copyCustomFields)
                .AddParameter("copyCustomStatuses", copyCustomStatuses)
                .AddParameter("copyStatuses", copyStatuses)
                .AddParameter("copyParents", copyParents)
                .AddParameter("rescheduleDate", rescheduleDate, new CustomDateTimeConverter("yyyy-MM-dd"))
                .AddParameter("rescheduleMode", rescheduleMode)
                .AddParameter("entryLimit", entryLimit);

            var response = await SendRequest<WrikeFolder>($"copy_folder/{folderId}", HttpMethods.Post,
                contentBuilder.GetContent()).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }

        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.UpdateAsync(WrikeClientIdParameter folderId, string title, string description, List<string> addParents, List<string> removeParents, List<string> addShareds, List<string> removeShareds, List<WrikeMetadata> metadata, bool? restore, List<WrikeCustomFieldData> customFields, List<string> customColumns, WrikeProject project)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (title.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(title));
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

        async Task<IEnumerable<WrikeFolder>> IWrikeFoldersAndProjectsClient.UpdateFoldersAsync(WrikeClientIdListParameter folderIds, List<WrikeCustomFieldData> customFields, List<string> optionalFields)
        {
	        var uriBuilder = new WrikeUriBuilder($"folders/{folderIds}")
		        .AddParameter("fields", optionalFields);

	        var contentBuilder = new WrikeFormUrlEncodedContentBuilder()
		        .AddParameter("customFields", customFields);

	        var response = await SendRequest<WrikeFolder>(uriBuilder.GetUri(), HttpMethods.Put, contentBuilder.GetContent()).ConfigureAwait(false);
	        return GetReponseDataList(response);

        }


        async Task<WrikeFolder> IWrikeFoldersAndProjectsClient.DeleteAsync(WrikeClientIdParameter folderId)
        {
            var response = await SendRequest<WrikeFolder>($"folders/{folderId} ", HttpMethods.Delete).ConfigureAwait(false);
            return GetReponseDataFirstItem(response);
        }
    }
}

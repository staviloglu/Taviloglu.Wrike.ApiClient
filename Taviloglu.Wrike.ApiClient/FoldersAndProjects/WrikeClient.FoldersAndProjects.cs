using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
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
        async Task<WrikeResDto<WrikeFolder>> IWrikeFoldersAndProjectsClient.GetFoldersAsync(List<string> folderIds, List<string> optionalFields)
        {

            if (folderIds == null || folderIds.Count < 1)
            {
                throw new ArgumentNullException("folderIds can not be null or empty");
            }
            if (folderIds.Count > 100)
            {
                throw new ArgumentException("folderIds max count is 100");
            }

            var requestUri = "folders/" + string.Join(",", folderIds);

            if (optionalFields != null && optionalFields.Count > 0)
            {
                requestUri += "?fields=" + JsonConvert.SerializeObject(optionalFields);
            }

            return await SendRequest<WrikeFolder>(requestUri, HttpMethods.Get);
        }

        async Task<WrikeResDto<WrikeFolderTree>> IWrikeFoldersAndProjectsClient.GetFolderTreeAsync(string accountId, string folderId, string permalink, bool? addDescendants, WrikeMetadata metadata, WrikeCustomFieldData customField, WrikeDateFilterRange updatedDate, bool? isProject, bool? isDeleted, List<string> fields)
        {
            if (!string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(folderId))
            {
                throw new ArgumentException("only folderId or accountId can be used, not both!");
            }

            var requestUri = "folders";

            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/folders";
            }
            else if (!string.IsNullOrWhiteSpace(folderId))
            {
                requestUri = $"folders/{folderId}/folders";
            }

            var filterHelper = new WrikeGetParametersHelper();
            filterHelper.AddFilterIfNotNull("permalink", permalink);
            filterHelper.AddFilterIfNotNull("descendants", addDescendants);
            filterHelper.AddFilterIfNotNull("metadata", metadata);
            filterHelper.AddFilterIfNotNull("customField", customField);
            filterHelper.AddFilterIfNotNull("updatedDate",
                updatedDate, new CustomDateTimeConverter("yyyy-MM-dd'T'HH:mm:ss'Z'"));
            filterHelper.AddFilterIfNotNull("project", isProject);
            if (!string.IsNullOrWhiteSpace(folderId))
            {
                filterHelper.AddFilterIfNotNull("deleted", isDeleted);
            }
            filterHelper.AddFilterIfNotNull("fields", fields);
            requestUri += filterHelper.GetFilterParametersText();

            return await SendRequest<WrikeFolderTree>(requestUri, HttpMethods.Get);
        }
    }
}

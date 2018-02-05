using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

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

        async Task<WrikeResDto<WrikeFolderTree>> IWrikeFoldersAndProjectsClient.GetFolderTreeAsync(string accountId)
        {

            if (accountId == null)
            {
                return await SendRequest<WrikeFolderTree>("folders", HttpMethods.Get);
            }

            return await SendRequest<WrikeFolderTree>($"accounts/{accountId}/folders", HttpMethods.Get);
        }
    }
}

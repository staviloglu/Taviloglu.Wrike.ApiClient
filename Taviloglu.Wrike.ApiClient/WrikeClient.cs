using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public class WrikeClient
    {
        private readonly HttpClient _httpClient;
        public WrikeClient(string bearerToken)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(@"https://www.wrike.com/api/v3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
        }

        #region Users
        /// <summary>
        ///  Returns information about single user
        /// </summary>
        /// <remarks>Scopes: amReadOnlyUser, amReadWriteUser</remarks>
        /// <param name="id">userId</param>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-user"/>
        public async Task<WrikeResDto<WrikeUser>> QueryUserAsync(string id)
        {
            return await SendRequest<WrikeUser>($"users/{id}", HttpMethods.Get);
        }
        #endregion

        #region Tasks
        /// <summary>
        ///  Create task in folder. You can specify rootFolderId to create task in user's account root. 
        /// </summary>
        /// <remarks>Scopes: Default, wsReadWrite</remarks>
        /// <param name="folderId">folderId</param>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/create-task"/>
        public async Task<WrikeResDto<WrikeTask>> CreateTaskAsync(string folderId)
        {
            //TODO: implement            
            //return await SendRequest<WrikeTask>($"api/v3/folders/{folderId}/tasks", HttpMethods.Post, postData);
            return new WrikeResDto<WrikeTask>();
        }
        #endregion



        #region CustomFields
        /// <summary>
        /// Returns a list of custom fields in all accessible accounts
        /// </summary>
        /// <remarks>Scopes: Default, wsReadOnly, wsReadWrite</remarks>
        /// <param name="accountId">If provided; returns a list of custom fields in particular account</param>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        public async Task<WrikeResDto<WrikeCustomField>> GetCustomFieldsAsync(string accountId = null)
        {
            var requestUri = $"customfields";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/customfields";
            }

            return await SendRequest<WrikeCustomField>(requestUri, HttpMethods.Get);
        }

        /// <summary>
        /// Returns complete information about specified custom fields
        /// </summary>
        /// <remarks>Scopes: Default, wsReadOnly, wsReadWrite</remarks>
        /// <param name="customFieldIds">string list of customFiledIds</param>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        public async Task<WrikeResDto<WrikeCustomField>> GetCustomFiledInfoAsync(List<string> customFieldIds)
        {
            var customFieldsValue = string.Join(",", customFieldIds);
            return await SendRequest<WrikeCustomField>($"customfields/{customFieldsValue}", HttpMethods.Get);
        }

        /// <summary>
        /// Create custom field in specified account
        /// </summary>
        /// <remarks>Scopes: Default, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/create-custom-field"/>
        /// <param name="customField">AccountId, Title and Text values should be set</param>
        public async Task<WrikeResDto<WrikeCustomField>> CreateCustomFieldAsync(WrikeCustomField customField)
        {
            if (customField == null)
            {
                throw new ArgumentNullException("CustomField can not be null");
            }
            if (string.IsNullOrWhiteSpace(customField.AccountId))
            {
                throw new ArgumentNullException("customField.AccountId can not be null or empty");
            }
            if (string.IsNullOrWhiteSpace(customField.Type))
            {
                throw new ArgumentNullException("customField.Type can not be null or empty");
            }

            var data = new List<KeyValuePair<string, string>>();

            data.Add(new KeyValuePair<string, string>("title", customField.Title));
            data.Add(new KeyValuePair<string, string>("type", customField.Type));
            if (customField.SharedIds != null && customField.SharedIds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("shareds", GetArrayValue(customField.SharedIds)));
            }

            var postContent = new FormUrlEncodedContent(data);

            return await SendRequest<WrikeCustomField>($"accounts/{customField.AccountId}/customfields",
                HttpMethods.Post, postContent);
        }

        /// <summary>
        /// Updates custom field
        /// </summary>
        /// <remarks>Scopes: Default, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/modify-custom-field"/>        
        public async Task<WrikeResDto<WrikeCustomField>> UpdateCustomFieldAsync(
            string id, string title = null, string type = null, List<string> addShareds = null, List<string> removeShareds = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id can not be null");
            }

            var data = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(title))
            {
                data.Add(new KeyValuePair<string, string>("title", title));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                data.Add(new KeyValuePair<string, string>("type", type));

            }
            if (addShareds != null && addShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("addShareds", GetArrayValue(addShareds)));
            }
            if (removeShareds != null && removeShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("removeShareds", GetArrayValue(removeShareds)));
            }

            var putContent = new FormUrlEncodedContent(data);

            return await SendRequest<WrikeCustomField>($"customfields/{id}", HttpMethods.Put, putContent);
        }
        #endregion


        #region Colors
        /// <summary>
        /// Get color name - code mapping
        /// </summary>
        /// <remarks>Scopes: Default, wsReadOnly, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-colors"/>
        public async Task<WrikeResDto<WrikeColor>> GetColorsAsync()
        {
            return await SendRequest<WrikeColor>("colors", HttpMethods.Get);
        }
        #endregion

        #region PrivateMethods
        private async Task<WrikeResDto<T>> SendRequest<T>(string requestUri, string httpMethod,
            HttpContent httpContent = null)
        {
            HttpResponseMessage responseMessage = null;


            switch (httpMethod)
            {
                case HttpMethods.Get:
                    responseMessage = await _httpClient.GetAsync(requestUri);
                    break;
                case HttpMethods.Post:
                    responseMessage = await _httpClient.PostAsync(requestUri, httpContent);
                    break;
                case HttpMethods.Put:
                    responseMessage = await _httpClient.PutAsync(requestUri, httpContent);
                    break;
                case HttpMethods.Delete:
                    break;
                default:
                    throw new ArgumentException("Unknown HTTP METHOD!");
            }
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<T>>(json);

            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }

            return wrikeResDto;
        }

        private string GetArrayValue(List<string> values)
        {
            var stringBuilder = new StringBuilder();

            if (values != null && values.Count > 0)
            {
                stringBuilder.Append("[");
                foreach (var value in values)
                {
                    stringBuilder.Append($"\"{value}\"");
                }
                stringBuilder.Append("]");
            }

            return stringBuilder.ToString();
        }
        #endregion

        private class HttpMethods
        {
            public const string Get = "GET";
            public const string Post = "POST";
            public const string Put = "PUT";
            public const string Delete = "DELETE";
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<WrikeResDto<WrikeUser>> QueryUserAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"users/{id}");
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<WrikeUser>>(json);

            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }

            return wrikeResDto;
        }

        public async Task<WrikeResDto<WrikeTask>> CreateTaskAsync(string folderId)
        {
            var postData = new CreateTaskRequest();
            var responseMessage = await _httpClient.PostAsJsonAsync($"api/v3/folders/{folderId}/tasks", postData);
            responseMessage.EnsureSuccessStatusCode();
            var json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WrikeResDto<WrikeTask>>(json);
        }




        #region CustomFields
        /// <summary>
        /// Returns a list of custom fields in all accessible accounts
        /// </summary>
        /// <remarks>Scopes: Default, wsReadOnly, wsReadWrite</remarks>
        /// <param name="accountId">If provided; returns a list of custom fields in particular account</param>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        public async Task<WrikeResDto<WrikeCustomField>> GetCustomFields(string accountId = null)
        {
            var requestUri = $"customfields";
            if (!string.IsNullOrWhiteSpace(accountId))
            {
                requestUri = $"accounts/{accountId}/customfields";
            }

            var responseMessage = await _httpClient.GetAsync(requestUri);
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<WrikeCustomField>>(json);

            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }

            return wrikeResDto;
        }

        /// <summary>
        /// Returns complete information about specified custom fields
        /// </summary>
        /// <remarks>Scopes: Default, wsReadOnly, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-custom-fields"/>
        public async Task<WrikeResDto<WrikeCustomField>> GetCustomFiledInfo(List<string> customFieldIds)
        {
            var customFieldsValue = string.Join(",", customFieldIds);
            var requestUri = $"customfields/{customFieldsValue}";

            var responseMessage = await _httpClient.GetAsync(requestUri);
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<WrikeCustomField>>(json);

            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }

            return wrikeResDto;
        }

        /// <summary>
        /// Create custom field in specified account
        /// </summary>
        /// <remarks>Scopes: Default, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/create-custom-field"/>
        /// <param name="customField">AccountId, Title and Text values should be set</param>
        public async Task<WrikeResDto<WrikeCustomField>> CreateCustomField(WrikeCustomField customField)
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

            var requestUri = $"accounts/{customField.AccountId}/customfields";

            var data = new List<KeyValuePair<string, string>>();

            data.Add(new KeyValuePair<string, string>("title", customField.Title));
            data.Add(new KeyValuePair<string, string>("type", customField.Type));
            if (customField.SharedIds != null && customField.SharedIds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("shareds", GetArrayValue(customField.SharedIds)));
            }
            var postContent = new FormUrlEncodedContent(data);

            var responseMessage = await _httpClient.PostAsync(requestUri, postContent);
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<WrikeCustomField>>(json);
            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }
            return wrikeResDto;
        }

        /// <summary>
        /// Updates custom field
        /// </summary>
        /// <remarks>Scopes: Default, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/modify-custom-field"/>
        /// <param name="customField">AccountId, Title and Text values should be set</param>
        public async Task<WrikeResDto<WrikeCustomField>> UpdateCustomField(
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
            if (addShareds!= null && addShareds.Count>0)
            {
                data.Add(new KeyValuePair<string, string>("addShareds", GetArrayValue(addShareds)));
            }
            if (removeShareds != null && removeShareds.Count > 0)
            {
                data.Add(new KeyValuePair<string, string>("removeShareds", GetArrayValue(removeShareds)));
            }

            var requestUri = $"customfields/{id}";
            
            var postContent = new FormUrlEncodedContent(data);

            var responseMessage = await _httpClient.PutAsync(requestUri, postContent);
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<WrikeCustomField>>(json);
            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }
            return wrikeResDto;
        }
        #endregion

        /// <summary>
        /// Get color name - code mapping
        /// </summary>
        /// <remarks>Scopes: Default, wsReadOnly, wsReadWrite</remarks>
        /// See <see cref="https://developers.wrike.com/documentation/api/methods/query-colors"/>
        public async Task<WrikeResDto<WrikeColor>> GetColors()
        {
            var requestUri = "colors";

            var responseMessage = await _httpClient.GetAsync(requestUri);
            var json = await responseMessage.Content.ReadAsStringAsync();
            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<WrikeColor>>(json);

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

    }
}

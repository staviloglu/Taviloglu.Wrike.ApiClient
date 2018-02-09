using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.Core;
using Taviloglu.Wrike.Core.Json;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Provides methods to access and modify user content in Wrike through the API
    /// </summary>
    public partial class WrikeClient
    {
        private readonly HttpClient _httpClient;
        public WrikeClient(string bearerToken)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(@"https://www.wrike.com/api/v3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
        }

        private async Task<WrikeResDto<T>> SendRequest<T>(
            string requestUri,
            string httpMethod,
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
                    responseMessage = await _httpClient.DeleteAsync(requestUri);
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

        private List<T> GetReponseDataList<T>(WrikeResDto<T> response)
        {
            if (string.IsNullOrWhiteSpace(response.Error))
            {
                throw new WrikeException(response.Error, response.ErrorDescription);
            }

            return response.Data;
        }

        private T GetReponseDataItem<T>(WrikeResDto<T> response)
        {
            if (string.IsNullOrWhiteSpace(response.Error))
            {
                throw new WrikeException(response.Error, response.ErrorDescription);
            }

            return response.Data[0];
        }

        private class HttpMethods
        {
            public const string Get = "GET";
            public const string Post = "POST";
            public const string Put = "PUT";
            public const string Delete = "DELETE";
        }

    }


}

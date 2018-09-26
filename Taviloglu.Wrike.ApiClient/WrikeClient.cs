using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.ApiClient.Exceptions;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Provides methods to access and modify user content in Wrike through the API
    /// </summary>
    public partial class WrikeClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeClient"/> class.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="host"></param>
        public WrikeClient(string bearerToken, string host = "www.wrike.com")
        {
            if (bearerToken == null)
            {
                throw new ArgumentNullException(nameof(bearerToken));
            }

            if (bearerToken.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(bearerToken));
            }

            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            if (host.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty",nameof(host));
            }

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($@"https://{host}/api/v4/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
        }
        private async Task<System.IO.Stream> SendRequestAndGetStream<T>(
            string requestUri,
            string httpMethod,
            HttpContent httpContent = null)
        {
            HttpResponseMessage responseMessage = null;

            switch (httpMethod)
            {
                case HttpMethods.Get:
                    responseMessage = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
                    break;
                case HttpMethods.Post:
                    responseMessage = await _httpClient.PostAsync(requestUri, httpContent).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentException("Unknown HTTP METHOD!");
            }
            var stream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);


            return stream;
        }
        private async Task<WrikeResDto<T>> SendRequest<T>(
            string requestUri,
            string httpMethod,
            HttpContent httpContent = null,
            JsonConverter jsonConverter = null)
        {
            HttpResponseMessage responseMessage = null;

            switch (httpMethod)
            {
                case HttpMethods.Get:
                    responseMessage = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
                    break;
                case HttpMethods.Post:
                    responseMessage = await _httpClient.PostAsync(requestUri, httpContent).ConfigureAwait(false);
                    break;
                case HttpMethods.Put:
                    responseMessage = await _httpClient.PutAsync(requestUri, httpContent).ConfigureAwait(false);
                    break;
                case HttpMethods.Delete:
                    responseMessage = await _httpClient.DeleteAsync(requestUri).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentException("Unknown HTTP METHOD!");
            }
            var json = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            WrikeResDto<T> wrikeResDto;

            if (jsonConverter != null)
            {
                wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<T>>(json, jsonConverter);
            }
            else
            {
                wrikeResDto =JsonConvert.DeserializeObject<WrikeResDto<T>>(json);
            }
            

            if (responseMessage.IsSuccessStatusCode)
            {
                wrikeResDto.IsSuccess = true;
            }

            return wrikeResDto;
        }

        private List<T> GetReponseDataList<T>(WrikeResDto<T> response)
        {
            if (!string.IsNullOrWhiteSpace(response.Error))
            {
                throw new WrikeApiException(response.Error, response.ErrorDescription);
            }

            return response.Data;
        }

        private T GetReponseDataFirstItem<T>(WrikeResDto<T> response)
        {
            if (!string.IsNullOrWhiteSpace(response.Error))
            {
                throw new WrikeApiException(response.Error, response.ErrorDescription);
            }

            return response.Data[0];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <b>false</b> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    if (_httpClient != null)
                    {
                        _httpClient.Dispose();
                    }
                }
            }
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

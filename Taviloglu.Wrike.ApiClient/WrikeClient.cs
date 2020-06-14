using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Taviloglu.Wrike.ApiClient.Dto;
using Taviloglu.Wrike.ApiClient.Dto.Authorization;
using Taviloglu.Wrike.ApiClient.Exceptions;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// Provides methods to access and modify user content in Wrike through the API
    /// </summary>
    public partial class WrikeClient : IDisposable
    {
        private HttpClient _httpClient;
        private bool _disposed;

        private string _host;
        private string _bearerToken;
        private string _refreshToken;
        private string _clientId;
        private string _clientSecret;
        private string _redirectUri;

        private void InitializeHttpClient(HttpClient customHttpClient)
        {
            _httpClient = customHttpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri($@"https://{_host}/api/v4/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_bearerToken}");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeClient"/> class.
        /// </summary>
        /// <param name="bearerToken">Permanent token / acces token </param>
        /// <param name="host">Host </param>
        /// <param name="customHttpClient">Custom implementation of HttpClient.
        /// Commonly used to add throttling to the number of requests made to the Wrike API</param>
        public WrikeClient(string bearerToken, string host = "www.wrike.com", HttpClient customHttpClient = null)
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
                throw new ArgumentException("value can not be empty", nameof(host));
            }

            _bearerToken = bearerToken;
            _host = host;

            InitializeHttpClient(customHttpClient);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrikeClient"/> class.
        /// </summary>
        /// <param name="accessTokenRequest"></param>
        /// <param name="redirectUri">Must provide if used in authorization url</param>
        /// <param name="customHttpClient">Custom implementation of HttpClient.
        /// Commonly used to add throttling to the number of requests made to the Wrike API</param>
        public WrikeClient(WrikeAccessTokenRequest accessTokenRequest, string redirectUri, HttpClient customHttpClient = null)
        {
            if (accessTokenRequest == null)
            {
                throw new ArgumentException(nameof(accessTokenRequest));
            }

            if (redirectUri == null)
            {
                throw new ArgumentNullException(nameof(redirectUri));
            }

            if (redirectUri.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(redirectUri));
            }

            var accessTokenResponse = GetAccesToken(accessTokenRequest, redirectUri);

            _clientId = accessTokenRequest.ClientId;
            _clientSecret = accessTokenRequest.ClientSecret;
            _redirectUri = redirectUri;
            _refreshToken = accessTokenResponse.RefreshToken;
            _bearerToken = accessTokenResponse.AccessToken;
            _host = accessTokenResponse.Host;

            InitializeHttpClient(customHttpClient);
        }

        /// <summary>
        /// Refereshes the access token
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/oauth2"/>
        public void RefreshToken()
        {
            if (string.IsNullOrWhiteSpace(_refreshToken))
            {
                throw new Exception("You are using permanent token!");
            }

            var parameters = GetNameValueCollection(_clientId, _clientSecret, _refreshToken, GrantType.refresh_token);

            var response = string.Empty;

            using (var webClient = new WebClient())
            {
                try
                {
                    var responseBytes = webClient.UploadValues($"https://{_host}/oauth2/token", "POST",
                      parameters);
                    response = webClient.Encoding.GetString(responseBytes);
                    var refreshTokenResponse = JsonConvert.DeserializeObject<WrikeRefreshTokenResponse>(response);

                    _refreshToken = refreshTokenResponse.RefreshToken;
                    _bearerToken = refreshTokenResponse.AccessToken;
                    _httpClient.DefaultRequestHeaders.Remove("Authorization");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_bearerToken}");
                }
                catch (WebException exception)
                {
                    using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                    {
                        var errorResponse = reader.ReadToEnd();
                        var er = JsonConvert.DeserializeAnonymousType(errorResponse, new { error = "", error_description = "" });
                        throw new WrikeApiException(er.error, er.error_description);
                    }
                }
            }
        }

        /// <summary>
        /// Refereshes the access token
        /// </summary>
        /// See <see href="https://developers.wrike.com/documentation/oauth2"/>
        public static WrikeRefreshTokenResponse RefreshToken(string clientId, string clientSecret, string refreshToken, string host)
        {
            var parameters = GetNameValueCollection(clientId, clientSecret, refreshToken, GrantType.refresh_token);

            var response = string.Empty;

            using (var webClient = new WebClient())
            {
                try
                {
                    var responseBytes = webClient.UploadValues($"https://{host}/oauth2/token", "POST",
                      parameters);
                    response = webClient.Encoding.GetString(responseBytes);
                }
                catch (WebException exception)
                {
                    using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                    {
                        var errorResponse = reader.ReadToEnd();
                        var er = JsonConvert.DeserializeAnonymousType(errorResponse, new { error = "", error_description = "" });
                        throw new WrikeApiException(er.error, er.error_description);
                    }
                }
            }

            return JsonConvert.DeserializeObject<WrikeRefreshTokenResponse>(response);
        }

        /// <summary>
        /// The URL that user will click to start the authorization process
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="redirectUri"></param>
        /// <param name="state"></param>
        /// <param name="scope"></param>
        /// See <see href="https://developers.wrike.com/documentation/oauth2"/>
        public static string GetAuthorizationUrl(string clientId, string redirectUri = null, string state = null, List<string> scope = null)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (clientId.Trim() == string.Empty)
            {
                throw new ArgumentException("value can not be empty", nameof(clientId));
            }

            var uriBuilder = new WrikeUriBuilder("https://www.wrike.com/oauth2/authorize/v4")
                .AddParameter("client_id", clientId)
                .AddParameter("response_type", "code")
                .AddParameter("redirect_uri", redirectUri)
                .AddParameter("state", state)
                .AddParameter("scope", string.Join(",", scope));


            return uriBuilder.GetUri();
        }

        /// <summary>
        /// Request access credentials
        /// </summary>
        /// <param name="accessTokenRequest"></param>
        /// <param name="redirectUri"></param>
        /// See <see href="https://developers.wrike.com/documentation/oauth2"/>
        public static WrikeAccessTokenResponse GetAccesToken(WrikeAccessTokenRequest accessTokenRequest, string redirectUri)
        {
            if (accessTokenRequest == null)
            {
                throw new ArgumentNullException(nameof(accessTokenRequest));
            }

            var parameters = GetNameValueCollection(accessTokenRequest.ClientId, accessTokenRequest.ClientSecret,
                accessTokenRequest.AuthorizationCode, accessTokenRequest.GrantType);
            parameters.Add("redirect_uri", redirectUri);

            var response = string.Empty;

            using (var webClient = new WebClient())
            {
                try
                {
                    var responseBytes = webClient.UploadValues("https://www.wrike.com/oauth2/token", "POST",
                      parameters);
                    response = webClient.Encoding.GetString(responseBytes);
                }
                catch (WebException exception)
                {
                    using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                    {
                        var errorResponse = reader.ReadToEnd();
                        var er = JsonConvert.DeserializeAnonymousType(errorResponse, new { error = "", error_description = "" });
                        throw new WrikeApiException(er.error, er.error_description);
                    }
                }
            }

            return JsonConvert.DeserializeObject<WrikeAccessTokenResponse>(response);
        }


        private static NameValueCollection GetNameValueCollection(string clientId, string clientSecret,
            string grantData, GrantType grantType)
        {
            var parameters = new NameValueCollection();
            parameters.Add("client_id", clientId);
            parameters.Add("client_secret", clientSecret);
            if (grantType == GrantType.authorization_code)
            {
                parameters.Add("code", grantData);
            }
            else
            {
                parameters.Add("refresh_token", grantData);
            }
            parameters.Add("grant_type", grantType.ToString());

            return parameters;
        }

        private async Task<System.IO.Stream> SendRequestAndGetStream(
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

        private async Task<WrikeResDto<T>> PostFile<T>(string requestUri, string fileName, byte[] fileBytes)
        {
            string json = string.Empty;
            bool isSuccess = false;

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                requestMessage.Headers.Add("X-Requested-With", "XMLHttpRequest");
                requestMessage.Content = new ByteArrayContent(fileBytes)
                {
                    Headers = {
                        { "content-type", "application/octet-stream" },
                        { "X-File-Name", fileName },
                    }
                };

                using (var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false))
                {
                    isSuccess = responseMessage.IsSuccessStatusCode;
                    json = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }

            var wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<T>>(json);
            wrikeResDto.IsSuccess = isSuccess;

            return wrikeResDto;
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
                wrikeResDto = JsonConvert.DeserializeObject<WrikeResDto<T>>(json);
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

                if (disposing && _httpClient != null)
                {
                    _httpClient.Dispose();
                }
            }
        }

        private static class HttpMethods
        {
            public const string Get = "GET";
            public const string Post = "POST";
            public const string Put = "PUT";
            public const string Delete = "DELETE";
        }
    }
}

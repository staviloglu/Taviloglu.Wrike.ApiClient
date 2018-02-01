using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Taviloglu.Wrike.Core;

namespace Taviloglu.Wrike.ApiClient
{
    public class WrikeClient
    {
        private readonly HttpClient _httpClient;
        public WrikeClient(string bearerToken)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://www.wrike.com/api/v3/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Taviloglu.Wrike.ApiClient");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {bearerToken}");
        }

        public async Task<WrikeResponse<WrikeUser>> QueryUserAsync(string id)
        {
            WrikeResponse<WrikeUser> user = null;

            var responseMessage = await _httpClient.GetAsync($"users/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<WrikeResponse<WrikeUser>>(json);
            }

            return user;
        }

        public async Task<WrikeResponse<WrikeTask>> CreateTaskAsync(string folderId)
        {
            var postData = new CreateTaskRequest();
            var responseMessage = await _httpClient.PostAsJsonAsync($"folders/{folderId}/tasks",postData);
            responseMessage.EnsureSuccessStatusCode();
            var json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WrikeResponse<WrikeTask>>(json);
        }
    }
}

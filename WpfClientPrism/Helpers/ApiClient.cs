
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfClientPrism.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public ApiClient()
        {
            BaseEndpoint = new Uri("https://localhost:44318/api/");
            _httpClient = new HttpClient();
        }
        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject< T>(data);
        }
        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

    }
}

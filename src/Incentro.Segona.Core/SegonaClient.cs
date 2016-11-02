﻿using Incentro.Segona.Core.Abstractions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Incentro.Segona.Core
{
    public class SegonaClient : ISegonaClient
    {
        private HttpClient _client;
        private UriHandler _handler;
        private string _segonaUrl;

        public SegonaClient(string segonaApiUrl)
        {
            _segonaUrl = segonaApiUrl;
            _client = new HttpClient();
            _handler = new UriHandler();
        }


        public async Task<IResponse> SearchAsync(RequestSettings settings)
        {
            var url = _handler.CreateApiUrl(_segonaUrl, "search", settings);
            var response = await _client.GetAsync(url);
            return JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> GetAssetById<T>(RequestSettings settings) where T : IAsset
        {
            var url = _handler.CreateApiUrl(_segonaUrl, "get", settings);
            var response = await _client.GetAsync(url);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IResponse> GetAllAsync(RequestSettings settings)
        {
            var url = _handler.CreateApiUrl(_segonaUrl, "list", settings);
            if (settings.Debug)
            {
                Debug.Write("Request url" + url);
            }
            var response = await _client.GetAsync(url);
            return JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IResponse> FilterAsync(RequestSettings settings)
        {
            var url = _handler.CreateApiUrl(_segonaUrl, "filter", settings);
            if (settings.Debug)
            {
                Debug.Write("Request url" + url);
            }
            var response = await _client.GetAsync(url);
            return JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
        }
    }
}
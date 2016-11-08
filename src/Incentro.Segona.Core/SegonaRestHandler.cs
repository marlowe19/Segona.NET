using System;
using System.Net.Http;
using System.Threading.Tasks;
using Incentro.Segona.Core.Abstractions;
using Incentro.Segona.Core.Factories;
using Incentro.Segona.Core.Models;
using Incentro.Segona.Core.Utils;

namespace Incentro.Segona.Core
{
    public class SegonaRestHandler : ISegonaHandler
    {
        public SegonaRestHandler(SegonaBuilderConfiguration configuration)
        {
            HttpClient = configuration.HttpClient;
            ApiUrl = new Uri(configuration.Options.ApiUrl);
        }

        public SegonaRestHandler(Uri apiUrl, HttpClient httpClient = null)
        {
            HttpClient = httpClient ?? new HttpClient();
            ApiUrl = apiUrl;
        }

        public HttpClient HttpClient { get; protected set; }

        public Uri ApiUrl { get; set; }

        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync(string apiKey)
        {
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "keycheck"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<Keycheck>(uriBuilder.Uri);
        }
        
        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(string apiKey, int limit = 50, int? startFromId = null)
        {
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "list"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("limit", limit);
            if (startFromId != null)
            {
                queryBuilder.Append("startFromId", startFromId);
            }

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<AssetList>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<Asset>> GetSpecificAssetAsync(string apiKey, Guid id)
        {
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "get"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("id", id);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<Asset>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<AssetList>> SearchAssetsAsync(string apiKey, string query, int limit = 50)
        {
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "search"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("query", query);
            queryBuilder.Append("limit", limit);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<AssetList>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<AssetList>> FilteredSearchAssetsAsync(string apiKey, string query, int limit = 50, string extraQuery = null, string color = null)
        {
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "filter"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("query", query);
            queryBuilder.Append("limit", limit);
            if (extraQuery != null)
            {
                queryBuilder.Append("query_extra", extraQuery);
            }

            if (color != null)
            {
                queryBuilder.Append("color", color);
            }

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<AssetList>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrlAsync(string apiKey)
        {
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "upload"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<UploadUrlObject>(uriBuilder.Uri);
        }

        protected async Task<SegonaResponse<T>> SendRequest<T>(Uri uri)
        {
            var response = await HttpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var resultAsString = await response.Content.ReadAsStringAsync();
                return SegonaResponseFactory.CreateSuccesful<T>(resultAsString);
            }

            return SegonaResponseFactory.CreateNonSuccesful<T>(response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}

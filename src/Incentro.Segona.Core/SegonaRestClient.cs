using System;
using System.Net.Http;
using System.Threading.Tasks;
using Incentro.Segona.Core.Abstractions;
using Incentro.Segona.Core.Configuration;
using Incentro.Segona.Core.Factories;
using Incentro.Segona.Core.Models;
using Incentro.Segona.Core.Utils;

namespace Incentro.Segona.Core
{
    public class SegonaClientV2
    {
        public SegonaClientV2(ISegona segona, SegonaConfiguration configuration)
        {
            Segona = segona;
            Configuration = configuration;
        }

        protected ISegona Segona { get; set; }

        protected SegonaConfiguration Configuration { get; set; }

        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync()
        {
            return await Segona.ApiKeyCheckAsync(new Uri(Configuration.ApiUrl + "keycheck"), Configuration.ApiKey);
        }

        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(int limit = 50, int? startFromId = null)
        {
            return await Segona.GetAllAssetsAsync(new Uri(Configuration.ApiUrl + "list"), Configuration.ApiKey, limit, startFromId);
        }

        public async Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Guid id)
        {
            return await Segona.GetSpecificAssetAsync(new Uri(Configuration.ApiUrl + "get"), Configuration.ApiKey, id);
        }

        public async Task<SegonaResponse<AssetList>> SearchAssets(string query, int limit = 50)
        {
            return await Segona.SearchAssets(new Uri(Configuration.ApiUrl + "search"), Configuration.ApiKey, query, limit);
        }

        public async Task<SegonaResponse<AssetList>> FilteredSearchAssets(string query, int limit = 50, string extraQuery = null, string color = null)
        {
            return await Segona.FilteredSearchAssets(new Uri(Configuration.ApiUrl + "search"), Configuration.ApiKey, query, limit, extraQuery, color);
        }

        public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrl()
        {
            return await Segona.GetUploadUrl(new Uri(Configuration.ApiUrl + "upload"), Configuration.ApiKey);
        }
    }

    public class SegonaRestClient : ISegona
    {
        public SegonaRestClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; protected set; }

        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync(Uri apiUrl, string apiKey)
        {
            var uriBuilder = new UriBuilder(apiUrl);
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<Keycheck>(uriBuilder.Uri);
        }
        
        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(Uri apiUrl, string apiKey, int limit = 50, int? startFromId = null)
        {
            var uriBuilder = new UriBuilder(apiUrl);
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

        public async Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Uri apiUrl, string apiKey, Guid id)
        {
            var uriBuilder = new UriBuilder(apiUrl);
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("id", id);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<AssetDetail>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<AssetList>> SearchAssets(Uri apiUrl, string apiKey, string query, int limit = 50)
        {
            var uriBuilder = new UriBuilder(apiUrl);
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("query", query);
            queryBuilder.Append("limit", limit);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<AssetList>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<AssetList>> FilteredSearchAssets(Uri apiUrl, string apiKey, string query, int limit = 50, string extraQuery = null, string color = null)
        {
            var uriBuilder = new UriBuilder(apiUrl);
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

        public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrl(Uri apiUrl, string apiKey)
        {
            var uriBuilder = new UriBuilder(apiUrl);
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

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Incentro.Segona.Core.Abstractions;
using Incentro.Segona.Core.Factories;
using Incentro.Segona.Core.Logging;
using Incentro.Segona.Core.Models;
using Incentro.Segona.Core.Utils;
using Microsoft.Extensions.Logging;

namespace Incentro.Segona.Core
{
    public class SegonaRestHandler : ISegonaHandler
    {
        public SegonaRestHandler(SegonaBuilderConfiguration configuration, ILoggerFactory loggerFactory)
        {
            HttpClient = configuration.HttpClient;
            ApiUrl = new Uri(configuration.Options.ApiUrl);
            Logger = loggerFactory.CreateLogger("Segona Rest Handler");
        }

        public SegonaRestHandler(Uri apiUrl, HttpClient httpClient = null, ILogger logger = null)
        {
            HttpClient = httpClient ?? new HttpClient();
            ApiUrl = apiUrl;
            Logger = logger ?? new EmptyLogger();
        }

        public HttpClient HttpClient { get; protected set; }

        public Uri ApiUrl { get; set; }

        public ILogger Logger { get; set; }

        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync(string apiKey)
        {
            Logger.LogInformation("Initiated 'API Keycheck'");
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "keycheck"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<Keycheck>(uriBuilder.Uri);
        }
        
        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(string apiKey, int limit = 50, int? startFromId = null)
        {
            Logger.LogInformation("Initiated 'Get All Assets'");
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
            Logger.LogInformation("Initiated 'Get Specific Asset'");
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "get"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);
            queryBuilder.Append("id", id);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<Asset>(uriBuilder.Uri);
        }

        public async Task<SegonaResponse<AssetList>> SearchAssetsAsync(string apiKey, string query, int limit = 50)
        {
            Logger.LogInformation("Initiated 'Search Assets'");
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
            Logger.LogInformation("Initiated 'Filtered Search Assets'");
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
            Logger.LogInformation("Initiated 'Get Upload URL'");
            var uriBuilder = new UriBuilder(new Uri(ApiUrl, "upload"));
            var queryBuilder = new UriQueryBuilder();
            queryBuilder.Append("apiKey", apiKey);

            uriBuilder.Query = queryBuilder.Build();
            return await SendRequest<UploadUrlObject>(uriBuilder.Uri);
        }

        protected async Task<SegonaResponse<T>> SendRequest<T>(Uri uri)
        {
            var logId = new EventId();
            Logger.LogInformation(logId, "Sending REST request");
            var response = await HttpClient.GetAsync(uri);
            Logger.LogInformation(logId, "Received REST response");
            if (response.IsSuccessStatusCode)
            {
                Logger.LogInformation(logId, "Response is successful");
            }
            else
            {
                Logger.LogWarning(logId, "Reponse is not successful");
            }

            return await SegonaResponseFactory.CreateFromHttpResponseMessage<T>(response);
        }
    }
}

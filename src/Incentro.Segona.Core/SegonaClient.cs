using System;
using System.Threading.Tasks;
using Incentro.Segona.Core.Abstractions;
using Incentro.Segona.Core.Models;

namespace Incentro.Segona.Core
{
    public class SegonaClient
    {
        public SegonaClient(ISegonaHandler handler, SegonaBuilderConfiguration configuration)
        {
            Handler = handler;
            ApiKey = configuration.Options.ApiKey;
        }

        public SegonaClient(ISegonaHandler handler, string apiKey)
        {
            Handler = handler;
            ApiKey = apiKey;
        }

        public static SegonaClient Create(SegonaOptions options)
        {
            return new SegonaClient(new SegonaRestHandler(new Uri(options.ApiUrl)), options.ApiKey);
        }

        protected ISegonaHandler Handler { get; set; }

        protected string ApiKey { get; set; }

        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync()
        {
            return await Handler.ApiKeyCheckAsync(ApiKey);
        }

        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(int limit = 50, int? startFromId = null)
        {
            return await Handler.GetAllAssetsAsync(ApiKey, limit, startFromId);
        }

        public async Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Guid id)
        {
            return await Handler.GetSpecificAssetAsync(ApiKey, id);
        }

        public async Task<SegonaResponse<AssetList>> SearchAssets(string query, int limit = 50)
        {
            return await Handler.SearchAssets(ApiKey, query, limit);
        }

        public async Task<SegonaResponse<AssetList>> FilteredSearchAssets(string query, int limit = 50, string extraQuery = null, string color = null)
        {
            return await Handler.FilteredSearchAssets(ApiKey, query, limit, extraQuery, color);
        }

        public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrl()
        {
            return await Handler.GetUploadUrl(ApiKey);
        }
    }
}

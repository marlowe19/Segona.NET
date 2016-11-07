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
            Options = configuration.Options;
        }

        public SegonaClient(ISegonaHandler handler, SegonaOptions options)
        {
            Handler = handler;
            Options = options;
        }

        protected ISegonaHandler Handler { get; set; }

        protected SegonaOptions Options { get; set; }

        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync()
        {
            return await Handler.ApiKeyCheckAsync(Options.ApiKey);
        }

        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(int limit = 50, int? startFromId = null)
        {
            return await Handler.GetAllAssetsAsync(Options.ApiKey, limit, startFromId);
        }

        public async Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Guid id)
        {
            return await Handler.GetSpecificAssetAsync(Options.ApiKey, id);
        }

        public async Task<SegonaResponse<AssetList>> SearchAssets(string query, int limit = 50)
        {
            return await Handler.SearchAssets(Options.ApiKey, query, limit);
        }

        public async Task<SegonaResponse<AssetList>> FilteredSearchAssets(string query, int limit = 50, string extraQuery = null, string color = null)
        {
            return await Handler.FilteredSearchAssets(Options.ApiKey, query, limit, extraQuery, color);
        }

        public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrl()
        {
            return await Handler.GetUploadUrl(Options.ApiKey);
        }
    }
}

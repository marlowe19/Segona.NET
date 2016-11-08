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

        /// <summary>
        /// Segona uses API keys to allow access to the API. 
        /// You can register a new Segona API key at our developer portal (https://segona.io/).
        /// </summary>
        public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync()
        {
            return await Handler.ApiKeyCheckAsync(ApiKey);
        }

        /// <summary>Retrieves all assets</summary>
        /// <param name="limit">How many items you want to retrieve in a single call.</param>
        /// <param name="startFromId">If supplied, results start from here. This is useful for pagination.</param>
        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(int limit = 50, int? startFromId = null)
        {
            return await Handler.GetAllAssetsAsync(ApiKey, limit, startFromId);
        }

        /// <summary>Retrieves a specific asset</summary>
        /// <param name="id">The ID of the asset to retrieve</param>
        public async Task<SegonaResponse<Asset>> GetSpecificAssetAsync(Guid id)
        {
            return await Handler.GetSpecificAssetAsync(ApiKey, id);
        }

        /// <summary>Searches all assets</summary>
        /// <param name="query">Your search term. Matches with labels, metadata, colors and the original file name</param>
        /// <param name="limit">How many items you want to retrieve in a single call.</param>
        public async Task<SegonaResponse<AssetList>> SearchAssetsAsync(string query, int limit = 50)
        {
            return await Handler.SearchAssetsAsync(ApiKey, query, limit);
        }

        /// <summary>Filters through assets</summary>
        /// <param name="query">Your search term. Matches with labels, metadata, colors and the original file name</param>
        /// <param name="limit">How many items you want to retrieve in a single call.</param>
        /// <param name="extraQuery">An extra query term which does an “AND” with the query parameter.</param>
        /// <param name="color">
        /// Either a 6 digit hexcode (e.g. #FFFFFF) or one of these strings:
        /// * Red
        /// * Blue
        /// * Green
        /// * Black
        /// * White
        /// * Orange
        /// * Grey
        /// * Yellow
        /// * Brown
        /// * Purple
        /// * Pink
        /// </param>
        public async Task<SegonaResponse<AssetList>> FilteredSearchAssetsAsync(string query, int limit = 50, string extraQuery = null, string color = null)
        {
            return await Handler.FilteredSearchAssetsAsync(ApiKey, query, limit, extraQuery, color);
        }

        /// <summary>Retrieves an upload url where you can upload your assets to</summary>
        public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrlAsync()
        {
            return await Handler.GetUploadUrlAsync(ApiKey);
        }
    }
}

using System;
using System.Threading.Tasks;
using Incentro.Segona.Core.Models;

namespace Incentro.Segona.Core.Abstractions
{
    public interface ISegona
    {
        /// <summary>
        /// Segona uses API keys to allow access to the API. 
        /// You can register a new Segona API key at our developer portal (https://segona.io/).
        /// </summary>
        /// <param name="apiUrl">The API url</param>
        /// <param name="apiKey">Your API key</param>
        Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync(Uri apiUrl, string apiKey);

        /// <summary>Retrieves all assets</summary>
        /// <param name="apiUrl">The API url</param>
        /// <param name="apiKey">Your API key</param>
        /// <param name="limit">How many items you want to retrieve in a single call.</param>
        /// <param name="startFromId">If supplied, results start from here. This is useful for pagination.</param>
        Task<SegonaResponse<AssetList>> GetAllAssetsAsync(Uri apiUrl, string apiKey, int limit = 50, int? startFromId = null);

        /// <summary>Retrieves a specific asset</summary>
        /// <param name="apiUrl">The API url</param>
        /// <param name="apiKey">Your API key</param>
        /// <param name="id">The ID of the asset to retrieve</param>
        Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Uri apiUrl, string apiKey, Guid id);

        /// <summary>Searches all assets</summary>
        /// <param name="apiUrl">The API url</param>
        /// <param name="apiKey">Your API key</param>
        /// <param name="query">Your search term. Matches with labels, metadata, colors and the original file name</param>
        /// <param name="limit">How many items you want to retrieve in a single call.</param>
        Task<SegonaResponse<AssetList>> SearchAssets(Uri apiUrl, string apiKey, string query, int limit = 50);

        /// <summary>Filters through assets</summary>
        /// <param name="apiUrl">The API url</param>
        /// <param name="apiKey">Your API key</param>
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
        Task<SegonaResponse<AssetList>> FilteredSearchAssets(Uri apiUrl, string apiKey, string query, int limit = 50, string extraQuery = null, string color = null);

        /// <summary>Retrieves an upload url where you can upload your assets to</summary>
        /// <param name="apiUrl">The API url</param>
        /// <param name="apiKey">Your API key</param>
        Task<SegonaResponse<UploadUrlObject>> GetUploadUrl(Uri apiUrl, string apiKey);
    }
}

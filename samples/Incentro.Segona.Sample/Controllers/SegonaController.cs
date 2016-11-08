using System;
using System.Threading.Tasks;
using Incentro.Segona.Core;
using Incentro.Segona.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Incentro.Segona.Sample.Controllers
{
    public class SegonaController : Controller
    {
        public SegonaController(SegonaClient segonaClient)
        {
            SegonaClient = segonaClient;
        }

        public SegonaClient SegonaClient { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ApiKeyCheck()
        {
            return ProcessResponse(await SegonaClient.ApiKeyCheckAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            return ProcessResponse(await SegonaClient.GetAllAssetsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecificAsset(Guid id)
        {
            return ProcessResponse(await SegonaClient.GetSpecificAssetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> SearchThroughAssets(string query)
        {
            return ProcessResponse(await SegonaClient.SearchAssetsAsync(query));
        }

        [HttpGet]
        public async Task<IActionResult> FilterSearchResults(string query, string extraQuery, string color)
        {
            return ProcessResponse(await SegonaClient.FilteredSearchAssetsAsync(query, extraQuery: extraQuery, color: color));
        }

        [HttpGet]
        public async Task<IActionResult> GetUploadUrl()
        {
            return ProcessResponse(await SegonaClient.GetUploadUrlAsync());
        }

        protected IActionResult ProcessResponse<T>(SegonaResponse<T> response)
        {
            return Ok(response.HttpMessage);
        }
    }
}

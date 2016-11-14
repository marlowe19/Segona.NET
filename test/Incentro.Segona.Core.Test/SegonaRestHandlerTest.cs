using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Incentro.Segona.Core.Models;
using Microsoft.Extensions.Logging.Debug;
using Xunit;

namespace Incentro.Segona.Core.Test
{
    public class SegonaRestHandlerTest : TestBase
    {
        public SegonaRestHandlerTest()
        {
            Handler = new SegonaRestHandler(new Uri(Options.ApiUrl), null, new DebugLogger("Segona Test Debug Logger"));
        }

        protected SegonaRestHandler Handler { get; set; }

        protected Uri BaseApiUrl { get; set; }

        [Fact]
        public async Task ApiKeyCheck_Valid()
        {
            var keycheck = await Handler.ApiKeyCheckAsync(Options.ApiKey);
            AssertValidResponse(keycheck);
            Assert.True(keycheck.Result.Valid);
        }

        [Fact]
        public async Task ApiKeyCheck_Invalid()
        {
            var keycheck = await Handler.ApiKeyCheckAsync("12345");
            AssertValidResponse(keycheck);
            Assert.False(keycheck.Result.Valid);
        }

        [Fact]
        public async Task GetAllAssets()
        {
            var assetList = await Handler.GetAllAssetsAsync(Options.ApiKey);
            AssertValidResponse(assetList);
        }

        [Fact]
        public async Task GetAllTasks_Should_Get_Unauthorized_With_Invalid_ApiKey()
        {
            var assetList = await Handler.GetAllAssetsAsync("12345");
            AssertInvalidResponse(assetList);
            Assert.Equal(HttpStatusCode.Unauthorized, assetList.StatusCode);
        }

        [Fact]
        public async Task GetSpecificAsset()
        {
            // First get assets
            var assetsResponse = await Handler.GetAllAssetsAsync(Options.ApiKey);
            Assert.NotNull(assetsResponse?.Result?.Items);
            var assets = assetsResponse.Result.Items;
            Assert.True(assets.Any(), "Upload assets first");
            var firstAsset = assets.First();

            var specificAssetResponse = await Handler.GetSpecificAssetAsync(Options.ApiKey, firstAsset.Id);
            AssertValidResponse(specificAssetResponse);
            Assert.Equal(firstAsset.Id, specificAssetResponse.Result.Id);
            Assert.Equal(firstAsset.OriginalName, specificAssetResponse.Result.OriginalName);
            Assert.Equal(firstAsset.Thumbnail, specificAssetResponse.Result.Thumbnail);
        }

        [Fact]
        public async Task GetSpecificAsset_NonExistant()
        {
            var specificAsset = await Handler.GetSpecificAssetAsync(Options.ApiKey, new Guid());
            AssertInvalidResponse(specificAsset);
            Assert.NotEmpty(specificAsset.Error.Error.Errors);
            Assert.Equal("notFound", specificAsset.Error.Error.Errors.First().Reason);
        }

        [Fact]
        public async Task SearchAssets()
        {
            // TODO: It's probably better to get an item first, scan for a tag, and then use that tag to search
            var searchAssets = await Handler.SearchAssetsAsync(Options.ApiKey, "ocean");
            AssertValidResponse(searchAssets);
            Assert.NotEmpty(searchAssets.Result.Items);
        }

        [Fact]
        public async Task SearchAssets_Impossible_Query()
        {
            var searchAssets = await Handler.SearchAssetsAsync(Options.ApiKey, "23r08usdvjksj");
            AssertValidResponse(searchAssets);
            Assert.True(searchAssets.Result.Items == null || !searchAssets.Result.Items.Any());
        }

        [Fact]
        public async Task FilterSearchAssets_With_Color()
        {
            var searchAssets = await Handler.FilteredSearchAssetsAsync(Options.ApiKey, "ocean", color: "Blue");
            AssertValidResponse(searchAssets);
            Assert.NotEmpty(searchAssets.Result.Items);
        }

        [Fact]
        public async Task FilterSearchAssets_With_ExtraQuery()
        {
            var searchAssets = await Handler.FilteredSearchAssetsAsync(Options.ApiKey, "ocean", extraQuery: "ship");
            AssertValidResponse(searchAssets);
            Assert.NotEmpty(searchAssets.Result.Items);
        }

        [Fact]
        public async Task GetUploadUrl()
        {
            var uploadUrl = await Handler.GetUploadUrlAsync(Options.ApiKey);
            AssertValidResponse(uploadUrl);
            Assert.False(string.IsNullOrEmpty(uploadUrl.Result.UploadUrl.ToString()));
        }

        protected void AssertValidResponse<T>(SegonaResponse<T> response)
        {
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Result);
        }

        protected void AssertInvalidResponse<T>(SegonaResponse<T> response)
        {
            Assert.NotNull(response);
            Assert.False(response.IsSuccessful);
            Assert.NotNull(response.Error);
        }

        protected Uri GetUrl(string relativePath)
        {
            return new Uri(Options.ApiUrl + relativePath);
        }
    }
}

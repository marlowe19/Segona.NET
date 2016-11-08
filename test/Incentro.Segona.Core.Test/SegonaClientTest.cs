using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Incentro.Segona.Core.Test
{
    public class ClientTest : TestBase
    {
        public ClientTest()
        {
            Client = SegonaClient.Create(Options);
        }

        public SegonaClient Client { get; set; }

        [Fact]
        public async Task Test()
        {
            var allAssets = await Client.GetAllAssetsAsync();
            var search = await Client.SearchAssetsAsync("ocean");
            var filtered = await Client.FilteredSearchAssetsAsync("ocean", color: "Purple");
        }
    }
}
using System;
using FluentAssertions;
using Incentro.Segona.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Incentro.Segona.Core.Test
{
    public class ClientTest : TestBase
    {
        public ClientTest()
        {
            Client = new SegonaClient(new SegonaRestHandler(new HttpClient(), new Uri(Options.ApiUrl)), Options);
        }

        public SegonaClient Client { get; set; }

        [Fact]
        public async Task Test()
        {
            var allAssets = await Client.GetAllAssetsAsync();
            var search = await Client.SearchAssets("ocean");
            var filtered = await Client.FilteredSearchAssets("ocean", color: "Purple");
        }
    }
}
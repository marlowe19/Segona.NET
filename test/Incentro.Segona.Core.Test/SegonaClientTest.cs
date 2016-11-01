using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Incentro.Segona.Core.Test.Extensions;
using Xunit;
using Xunit.Sdk;

namespace Incentro.Segona.Core.Test
{
    public class ClientTest : TestBase
    {
        [Fact]
        public async Task Get_Request_Should_Be_Of_Json_Type()
        {

            var client = new HttpClient();
            var uri = new UriHandler();
            var url = uri.CreateApiUrl(SegonaConfiguration.ApiUrl, "list", new RequestSettings { ApiKey = SegonaConfiguration.ApiKey });
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(url);
            response.Content.Headers.ContentType.ToString().Should().Contain("json");
        }

        [Theory]
        [InlineData("obama")]
        public async Task Search_Segona(string searchkeyword)
        {
            var uri = new UriHandler();
            var url = uri.CreateApiUrl(SegonaConfiguration.ApiUrl, "search", new RequestSettings { QueryString = searchkeyword, ApiKey = SegonaConfiguration.ApiKey });
            var webclient = new HttpClient();
            var result = await webclient.GetAsync(url);

            result.IsSuccessStatusCode.Should().BeTrue();
        }
        
        [Fact]
        public async Task Get_Single_Item_From_Segona()
        {
            var client = new HttpClient();
            var url =
                $"{SegonaConfiguration.ApiUrl}get?apiKey={SegonaConfiguration.ApiKey}&id=2b137408-f7a6-4357-ac7f-639adc9d8cad";
            var item = client.GetAsync(url).Result;

            item.IsSuccessStatusCode.Should().Be(false);
        }

        [Fact]
        public async Task Method_Exists()
        {
            var settings = new RequestSettings
            {
                Id = "2b137408-f7a6-4357-ac7f-639adc9d8cad",
                ApiKey = SegonaConfiguration.ApiKey
            };
            var client = new SegonaClient(SegonaConfiguration.ApiUrl);
            var segona = await client.GetAssetById(settings);

            segona.Should().NotBe(null);
        }
        [Fact]
        public void Should_Return_Correct_Single_Call_url_By_Id()
        {
            var urlToMatch =  $"{SegonaConfiguration.ApiUrl}get?apiKey={SegonaConfiguration.ApiKey}&id=2b137408-f7a6-4357-ac7f-639adc9d8cad";
            var uriClient = new UriHandler();

            var url = uriClient.CreateApiUrl(SegonaConfiguration.ApiUrl, "get",new RequestSettings {ApiKey = SegonaConfiguration.ApiKey, Id = "2b137408-f7a6-4357-ac7f-639adc9d8cad" });

            url.Should().BeEquivalentTo(urlToMatch);

        }

        
        [Fact]
        public async Task Is_the_right_Object_Passed()
        {
            var webclient = new SegonaClient(SegonaConfiguration.ApiUrl);
            var parameters = new RequestSettings
            {
                ApiKey = "15454545",
                QueryString = "blue",
                Limit = "10"
            };


            var isRequestSettings = parameters.GetType() == typeof(RequestSettings);

            var result = await webclient.GetAllAsync(parameters);

            Assert.Equal(true, isRequestSettings);
        }
        
        public async Task SegonaConnecionTest()
        {
            var webclient = new HttpClient();
            var result = await webclient.GetAsync(SegonaConfiguration.ApiUrl);
            Assert.Equal(true, result.IsSuccessStatusCode);
        }
    }
}

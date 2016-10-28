using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Incentro.Segona.Core.Application;
using NUnit.Framework;

namespace Incentro.Segona.Core.Test
{
    [TestFixture]
    public class ClientTest : TestBase
    {
        [Test]
        public async Task Get_Request_Should_Be_Of_Json_Type()
        {

            var client = new HttpClient();
            var uri = new UriHandler();
            var url = uri.CreateApiUrl(SegonaConfiguration.ApiUrl, "list", new RequestSettings { ApiKey = SegonaConfiguration.ApiKey });
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(url);
            response.Content.Headers.ContentType.ToString().Should().Contain("json");
        }

        [Test]
        [TestCase("obama")]
        public async Task Search_Segona(string searchkeyword)
        {
            var uri = new UriHandler();
            var url = uri.CreateApiUrl(SegonaConfiguration.ApiUrl, "search", new RequestSettings { QueryString = searchkeyword, ApiKey = SegonaConfiguration.ApiKey });
            var webclient = new HttpClient();
            var result = await webclient.GetAsync(url);

            result.IsSuccessStatusCode.Should().BeTrue();
        }

        [Test]
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

            Assert.AreEqual(true, isRequestSettings);
        }
        
        public async Task SegonaConnecionTest()
        {
            var webclient = new HttpClient();
            var result = await webclient.GetAsync(SegonaConfiguration.ApiUrl);
            Assert.AreEqual(true, result.IsSuccessStatusCode);
        }
    }
}

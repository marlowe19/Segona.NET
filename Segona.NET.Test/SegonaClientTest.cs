using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Configuration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Segona.Net.Application;
using Assert = NUnit.Framework.Assert;

namespace Segona.NET.Test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void Api_Key_Is_Of_Type_String()
        {
            
            var url = Settings.ApiUrl;
            var url2 = WebConfigurationManager.AppSettings.AllKeys;
            Settings.ApiKey.Should().BeOfType<string>();
        }


        [Test]
        public async Task Get_Request_Should_Be_Of_Json_Type()
        {

            var client = new HttpClient();
            var uri = new UriHandler();
            var url = uri.CreateApiUrl(Settings.ApiUrl,"list", new RequestSettings { ApiKey = Settings.ApiKey });
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(url);
            response.Content.Headers.ContentType.ToString().Should().Contain("json");

        }

        [Test]
        [TestCase("obama")]
        public async Task Search_Segona(string searchkeyword)
        {
            var client = new HttpClient();
            var uri = new UriHandler();
            var url = uri.CreateApiUrl(Settings.ApiUrl,"search", new RequestSettings { QueryString = searchkeyword, ApiKey = Settings.ApiKey });
            var webclient = new HttpClient();
            var result = await webclient.GetAsync(url);

            result.IsSuccessStatusCode.Should().BeTrue();

        }
        [Test]
        public async Task Is_the_right_Object_Passed()
        {
            var webclient = new SegonaClient(Settings.ApiUrl);
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
            var result = await webclient.GetAsync(Settings.ApiUrl);
            Assert.AreEqual(true, result.IsSuccessStatusCode);
        }


    }
}

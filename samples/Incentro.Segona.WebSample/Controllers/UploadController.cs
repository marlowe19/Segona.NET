using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Incentro.Segona.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incentro.Segona.WebSample.Controllers
{
    public class UploadController : Controller
    {
        public UploadController(SegonaBuilderConfiguration configuration, SegonaClient client)
        {
            Configuration = configuration;
            Client = client;
        }

        public SegonaBuilderConfiguration Configuration { get; set; }

        public SegonaClient Client { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var uploadUrl = await Client.GetUploadUrlAsync();
            if (!uploadUrl.IsSuccessful)
            {
                return BadRequest("Can't get the upload url from Segona");
            }

            var stringContent = new StringContent(Configuration.Options.ApiKey);
            stringContent.Headers.Add("Content-Disposition", "form-data; name=\"apiKey\"");

            var streamContent = new StreamContent(file.OpenReadStream());
            streamContent.Headers.Add("Content-Type", file.ContentType);
            streamContent.Headers.Add("Content-Disposition", file.ContentDisposition);

            var content = new MultipartFormDataContent
            {
                { streamContent, "myFile", file.FileName },
                { stringContent, "apiKey" }
            };

            var response = await Configuration.HttpClient.PostAsync(uploadUrl.Result.UploadUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest(await response.Content.ReadAsStringAsync());
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Incentro.Segona.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incentro.Segona.UploadTool.Controllers
{
    [Route("")]
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
            var uploadUrl = await Client.GetUploadUrl();
            if (!uploadUrl.IsSuccessful)
            {
                return BadRequest("Can't get the upload url from Segona");
            }

            string fileContent;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                fileContent = await reader.ReadToEndAsync();
            }

            var content = new SegonaContent(new Dictionary<string, string>
            {
                ["apiKey"] = Configuration.Options.ApiKey,
                ["file"] = fileContent
            });

            var response = await Configuration.HttpClient.PostAsync(uploadUrl.Result.UploadUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest(await response.Content.ReadAsStringAsync());
        }
    }
}
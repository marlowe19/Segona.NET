using System;
using System.Net.Http;
using System.Threading.Tasks;
using Incentro.Segona.Core.Abstractions;
using Incentro.Segona.Core.Factories;
using Incentro.Segona.Core.Models;
using Newtonsoft.Json;

namespace Incentro.Segona.Core
{
    public class SegonaWebClient : ISegona
    {


        public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(string apiKey, int limit = 50, int? startFromId = null)
        {
            using (var webClient = new HttpClient())
            {
                var uriBuilder = new UriBuilder("https://api-dot-segona-application.appspot.com/_ah/api/segona/v1/list");
                uriBuilder.Query += $"apiKey={apiKey}";
                uriBuilder.Query += $"&limit={limit}";
                if (startFromId != null)
                {
                    uriBuilder.Query += $"&startFromId={startFromId}";
                }

                var response = await webClient.GetAsync(uriBuilder.Uri);
                if (response.IsSuccessStatusCode)
                {
                    var resultAsString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AssetList>(resultAsString);
                    return SegonaResponseFactory.CreateSuccesful(result);
                }
                
                return SegonaResponseFactory.CreateNonSuccesful<AssetList>(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}

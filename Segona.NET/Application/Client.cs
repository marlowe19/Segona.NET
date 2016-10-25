using System.Net.Http;
using System.Threading.Tasks;
using Segona.NET.Application;
using Segona.NET.Application.Contracts;

namespace Segona.Net.Application
{
    public class SegonaClient
    {
        private HttpClient _client;
        private UriHandler _handler;
        private string _segonaUrl;
        public SegonaClient(string segonaApiUrl)
        {
              _segonaUrl = segonaApiUrl;
            _client = new HttpClient();
            _handler = new UriHandler();

        }
        public async Task<bool> ConnectAsync(string apiUrl)
        {
           var webclient = new HttpClient();

            var result = await webclient.GetAsync(apiUrl);

            if (result.IsSuccessStatusCode)
                _client = webclient;
            return result.IsSuccessStatusCode;
        }

        public async Task<IResponse> SearchAsync(RequestSettings settings)
        {
            var url = _handler.CreateApiUrl(_segonaUrl,"search", settings);
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsAsync<Response>();
        }
        public async Task<IResponse> GetAllAsync(RequestSettings settings)
        {
          
            var url = _handler.CreateApiUrl(_segonaUrl,"list",settings);
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsAsync<Response>(); 
        }

        public async Task<IResponse> FilterAsync(RequestSettings settings)
        {

            var url = _handler.CreateApiUrl(_segonaUrl,"filter", settings);
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsAsync<Response>();
        }
    }
}
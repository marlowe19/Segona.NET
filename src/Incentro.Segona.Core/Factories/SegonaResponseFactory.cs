using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Incentro.Segona.Core.Models;
using Newtonsoft.Json;

namespace Incentro.Segona.Core.Factories
{
    public static class SegonaResponseFactory
    {
        public static async Task<SegonaResponse<T>> CreateFromHttpResponseMessage<T>(HttpResponseMessage message)
        {
            string content = await message.Content.ReadAsStringAsync();
            return message.IsSuccessStatusCode ? CreateSuccessful<T>(content) : CreateNonSuccessful<T>(message.StatusCode, content);
        }

        private static SegonaResponse<T> CreateSuccessful<T>(string message)
        {
            return new SegonaResponse<T> { IsSuccessful = true, Result = JsonConvert.DeserializeObject<T>(message), HttpMessage = message, StatusCode = HttpStatusCode.OK };
        }

        private static SegonaResponse<T> CreateNonSuccessful<T>(HttpStatusCode statusCode, string message)
        {
            var response =  new SegonaResponse<T> { IsSuccessful = false, Result = default(T), StatusCode = statusCode, HttpMessage = message };
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.ServiceUnavailable:
                    response.Error = JsonConvert.DeserializeObject<ErrorObject>(message);
                    break;
            }

            return response;
        }

        
    }
}

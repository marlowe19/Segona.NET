using System.Net;
using Incentro.Segona.Core.Models;
using Newtonsoft.Json;

namespace Incentro.Segona.Core.Factories
{
    public static class SegonaResponseFactory
    {
        public static SegonaResponse<T> CreateSuccessful<T>(string message)
        {
            return new SegonaResponse<T> { IsSuccessful = true, Result = JsonConvert.DeserializeObject<T>(message), HttpMessage = message, StatusCode = HttpStatusCode.OK };
        }

        public static SegonaResponse<T> CreateNonSuccessful<T>(HttpStatusCode statusCode, string message)
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

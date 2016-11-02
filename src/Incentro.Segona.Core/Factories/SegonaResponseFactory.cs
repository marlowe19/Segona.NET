using System.Net;
using Incentro.Segona.Core.Models;

namespace Incentro.Segona.Core.Factories
{
    public static class SegonaResponseFactory
    {
        public static SegonaResponse<T> CreateSuccesful<T>(T result)
        {
            return new SegonaResponse<T> { IsSuccessful = true, Result =  result, StatusCode = HttpStatusCode.OK };
        }

        public static SegonaResponse<T> CreateNonSuccesful<T>(HttpStatusCode statusCode, string message)
        {
            return new SegonaResponse<T> { IsSuccessful = false, Result = default(T), StatusCode = statusCode, HttpMessage = message };
        }
    }
}

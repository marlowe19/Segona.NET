using System.Net;

namespace Incentro.Segona.Core.Models
{
    public class SegonaResponse<T>
    {
        public bool IsSuccessful { get; set; }

        public T Result { get; set; }

        public string HttpMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ErrorObject Error { get; set; }
    }
}

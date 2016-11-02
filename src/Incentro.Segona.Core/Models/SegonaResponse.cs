using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Incentro.Segona.Core.Models
{
    public class SegonaResponse<T>
    {
        public bool IsSuccessful { get; set; }

        public T Result { get; set; }

        public string HttpMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}

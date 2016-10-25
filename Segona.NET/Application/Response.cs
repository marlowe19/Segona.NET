using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Segona.Net.Application.Contracts;
using Segona.NET.Application.Contracts;

namespace Segona.NET.Application
{
    public class Response:IResponse
    {
        public List<IAsset> items { get; set; }
        public string kind { get; set; }
        public string etag { get; set; }
    }
}

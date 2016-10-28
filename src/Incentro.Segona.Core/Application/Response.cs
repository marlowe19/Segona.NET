using System.Collections.Generic;
using Incentro.Segona.Core.Application.Contracts;

namespace Incentro.Segona.Core.Application
{
    public class Response : IResponse
    {
        public List<Asset> items { get; set; }
        public string kind { get; set; }
        public string etag { get; set; }
    }
}
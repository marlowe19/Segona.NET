using Incentro.Segona.Core.Abstractions;
using System.Collections.Generic;

namespace Incentro.Segona.Core.Test
{
    public class ResponseTest : IResponse
    {
       
        public List<Asset> items { get; set; }
        public string kind { get; set; }
        public string etag { get; set; }
    }
}

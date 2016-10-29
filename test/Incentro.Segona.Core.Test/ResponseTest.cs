using System.Collections.Generic;
using Incentro.Segona.Core.Abstractions;

namespace Incentro.Segona.Core.Test
{
    public class ResponseTest : IResponse
    {
       
        public List<Asset> items { get; set; }
        public string kind { get; set; }
        public string etag { get; set; }
    }
}

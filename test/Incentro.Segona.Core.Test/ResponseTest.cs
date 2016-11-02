using Incentro.Segona.Core.Abstractions;
using System.Collections.Generic;

namespace Incentro.Segona.Core.Test
{
    public class ResponseTest : IResponse
    {
        public List<Asset> Items { get; set; }
        public string Kind { get; set; }
        public string Etag { get; set; }
    }
}
using Incentro.Segona.Core.Abstractions;
using System.Collections.Generic;

namespace Incentro.Segona.Core
{
    public class Response : IResponse
    {
        public List<Asset> Items { get; set; }
        public string Kind { get; set; }
        public string Etag { get; set; }
    }
}
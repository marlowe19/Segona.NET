using System.Collections.Generic;

namespace Incentro.Segona.Core.Abstractions
{
    public interface IResponse
    {
        List<Asset> Items { get; set; }
        string Kind { get; set; }
        string Etag { get; set; }
    }
}
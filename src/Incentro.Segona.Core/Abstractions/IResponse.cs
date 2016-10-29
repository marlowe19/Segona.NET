using System.Collections.Generic;

namespace Incentro.Segona.Core.Abstractions
{
    public interface IResponse
    {
        List<Asset> items { get; set; }
        string kind { get; set; }
        string etag { get; set; }
    }
}
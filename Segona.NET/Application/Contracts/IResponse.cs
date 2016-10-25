using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Segona.Net.Application.Contracts;

namespace Segona.NET.Application.Contracts
{
    public interface IResponse
    {
         List<IAsset> items { get; set; }
         string kind { get; set; }
         string etag { get; set; }
    }
}

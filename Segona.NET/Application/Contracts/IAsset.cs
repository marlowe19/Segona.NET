using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segona.Net.Application.Contracts
{
    public interface IAsset
    {
         string id { get; set; }
         string originalName { get; set; }
         string url { get; set; }
         string thumbnail { get; set; }
         string shareableUrl { get; set; }
         string kind { get; set; }
    }
}

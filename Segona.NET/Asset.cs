using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Segona.Net.Application.Contracts;

namespace Segona.NET
{
    public class Asset: IAsset
    {
        public string id { get; set; }
        public string originalName { get; set; }
        public string url { get; set; }
        public string thumbnail { get; set; }
        public string shareableUrl { get; set; }
        public string kind { get; set; }
    }
}

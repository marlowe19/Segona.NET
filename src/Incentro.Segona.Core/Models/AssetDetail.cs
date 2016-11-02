using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incentro.Segona.Core.Models
{
    public class AssetDetail
    {
        public Guid Id { get; set; }

        public string OriginalName { get; set; }

        public IDictionary<string, double> Labels { get; set; }

        public IEnumerable<string> Colors { get; set; }

        public IDictionary<string, string> RealColors { get; set; }

        public Uri Url { get; set; }

        public Uri Thumbnail { get; set; }

        public string Kind { get; set; }

        public string Etag { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Incentro.Segona.Core.Models
{
    public class AssetDetail
    {
        public Guid Id { get; set; }

        public string OriginalName { get; set; }

        public IDictionary<string, double> Labels { get; set; }

        public Xmp Xmp { get; set; }

        public Exif Exif { get; set; }

        public IEnumerable<string> Colors { get; set; }

        public IEnumerable<RealColor> RealColors { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<string> DetectedText { get; set; }

        public float Insertion { get; set; }

        public Uri Url { get; set; }

        public Uri Thumbnail { get; set; }

        public Uri ShareableUrl { get; set; }

        public string Kind { get; set; }

        public string Etag { get; set; }
    }
}

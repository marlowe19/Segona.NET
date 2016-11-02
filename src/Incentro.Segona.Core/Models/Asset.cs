using System;

namespace Incentro.Segona.Core.Models
{
    public class Asset
    {
        public Guid Id { get; set; }

        public string OriginalName { get; set; }

        public object Labels { get; set; }

        public object Xmp { get; set; }

        public object Exif { get; set; }

        public Uri Url { get; set; }

        public Uri Thumbnail { get; set; }

        public string Kind { get; set; }
    }
}

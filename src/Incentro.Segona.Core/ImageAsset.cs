using Incentro.Segona.Core.Abstractions;
using System.Collections.Generic;

namespace Incentro.Segona.Core
{
    public class ImageAsset : IImageAsset
    {
        public string Id { get; set; }
        public string OriginalName { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string ShareableUrl { get; set; }
        public string Kind { get; set; }
        public Dictionary<string, double> Labels { get; set; }
        public List<string> Colors { get; set; }
        public List<string> DetectedText { get; set; }
        public string RawData { get; set; }
    }
}
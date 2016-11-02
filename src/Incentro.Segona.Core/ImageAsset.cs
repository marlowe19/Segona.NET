using Incentro.Segona.Core.Abstractions;
using System.Collections.Generic;

namespace Incentro.Segona.Core
{
    public class ImageAsset : IImageAsset
    {
        public string id { get; set; }
        public string originalName { get; set; }
        public string url { get; set; }
        public string thumbnail { get; set; }
        public string shareableUrl { get; set; }
        public string kind { get; set; }
        public Dictionary<string, double> labels { get; set; }
        public List<string> colors { get; set; }
        public List<string> detectedText { get; set; }
        public string RawData { get; set; }
    }
}
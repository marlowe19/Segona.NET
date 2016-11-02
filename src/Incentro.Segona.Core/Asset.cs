using Incentro.Segona.Core.Abstractions;

namespace Incentro.Segona.Core
{
    public class Asset : IAsset
    {
        public string Id { get; set; }
        public string OriginalName { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string ShareableUrl { get; set; }
        public string Kind { get; set; }
    }
}
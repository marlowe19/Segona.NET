using Incentro.Segona.Core.Abstractions;

namespace Incentro.Segona.Core
{
    public class Asset : IAsset
    {
        public string id { get; set; }
        public string originalName { get; set; }
        public string url { get; set; }
        public string thumbnail { get; set; }
        public string shareableUrl { get; set; }
        public string kind { get; set; }
    }
}
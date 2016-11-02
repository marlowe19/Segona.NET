using System.Collections.Generic;

namespace Incentro.Segona.Core.Abstractions
{
    public interface IImageAsset : IAsset, IMetaData, IRawJsonData
    {
         string  id { get; set; }
         string originalName { get; set; }
         string url { get; set; }
         string thumbnail { get; set; }
         string shareableUrl { get; set; }
         string kind { get; set; }
         Dictionary<string,double> labels { get; set; }
         List<string> colors { get; set; }
         List<string> detectedText { get; set; }
    }
}
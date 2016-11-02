using System.Collections.Generic;

namespace Incentro.Segona.Core.Abstractions
{
    public interface IImageAsset : IAsset, IMetaData, IRawJsonData
    {
         Dictionary<string,double> Labels { get; set; }
         List<string> Colors { get; set; }
         List<string> DetectedText { get; set; }
    }
}
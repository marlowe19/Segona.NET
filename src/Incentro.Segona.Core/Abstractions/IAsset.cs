namespace Incentro.Segona.Core.Abstractions
{
    public interface IAsset
    {
        string Id { get; set; }
        string OriginalName { get; set; }
        string Url { get; set; }
        string Thumbnail { get; set; }
        string ShareableUrl { get; set; }
        string Kind { get; set; }
    }
}
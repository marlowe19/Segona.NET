namespace Incentro.Segona.Core.Application.Contracts
{
    public interface IAsset
    {
        string id { get; set; }
        string originalName { get; set; }
        string url { get; set; }
        string thumbnail { get; set; }
        string shareableUrl { get; set; }
        string kind { get; set; }
    }
}
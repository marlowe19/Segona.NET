using System.Net.Http;

namespace Incentro.Segona.Core
{
    public class SegonaBuilderConfiguration
    {
        public HttpClient HttpClient { get; set; } = new HttpClient();

        public SegonaOptions Options { get; set; } = new SegonaOptions();
    }
}

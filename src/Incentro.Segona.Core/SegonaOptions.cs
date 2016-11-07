namespace Incentro.Segona.Core
{
    public class SegonaOptions
    {
        public SegonaOptions()
        {
        }

        public SegonaOptions(string apiUrl, string apiKey)
        {
            ApiUrl = apiUrl;
            ApiKey = apiKey;
        }
        
        public string ApiUrl { get; set; }

        public string ApiKey { get; set; }
    }
}

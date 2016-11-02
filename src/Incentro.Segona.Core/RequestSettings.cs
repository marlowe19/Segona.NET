using Incentro.Segona.Core.Attributes;

namespace Incentro.Segona.Core
{
    public class RequestSettings
    {
        [QueryParameter("query")]
        public string QueryString { get; set; }

        [QueryParameter("apiKey")]
        public string ApiKey { get; set; }

        [QueryParameter("limit")]
        public string Limit { get; set; }

        [QueryParameter("query_extra")]
        public string ExtraQueryParameter { get; set; }

        public bool Debug { get; set; }

        [QueryParameter("id")]
        public string Id { get; set; }

        [QueryParameter("color")]
        public string Color { get; set; }
    }
}
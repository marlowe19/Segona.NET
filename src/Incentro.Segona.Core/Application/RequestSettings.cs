﻿using Incentro.Segona.Core.Application.Attributes;

namespace Incentro.Segona.Core.Application
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

        [QueryParameter("color")]
        public string Color { get; set; }

    }
}
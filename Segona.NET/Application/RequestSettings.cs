using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Segona.Net.Application.Attributes;

namespace Segona.Net.Application
{
    public class  RequestSettings
    {
       [QueryParameter("query")]
       public string QueryString { get; set; }

        [QueryParameter("apiKey")]
       public string ApiKey { get; set; }

       [QueryParameter("limit")]
       public string Limit { get; set; }

       [QueryParameter("query_extra")]
       public string ExtraQueryParameter { get; set; }


        [QueryParameter("color")]
        public string Color { get; set; }

    }
}
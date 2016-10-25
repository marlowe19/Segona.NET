using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Segona.Net.Application.Extensions;

namespace Segona.Net.Application
{
    public class UriHandler
    {
        public string CreateApiUrl(string apiUrl, string command,RequestSettings settings)
        {
            return $"{apiUrl}{command}?{settings.ToQueryString()}";
        }
    }
}
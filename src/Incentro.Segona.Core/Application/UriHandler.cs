﻿using Incentro.Segona.Core.Application.Extensions;

namespace Incentro.Segona.Core.Application
{
    public class UriHandler
    {
        public string CreateApiUrl(string apiUrl, string command, RequestSettings settings)
        {
            var query = settings.ToQueryString();
            return $"{apiUrl}{command}?{settings.ToQueryString()}";
        }
    }
}
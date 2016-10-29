using Incentro.Segona.Core.Extensions;

namespace Incentro.Segona.Core
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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Incentro.Segona.Sample
{
    public class SegonaContent : ByteArrayContent
    {
        public SegonaContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection) : base(GetCollectionBytes(nameValueCollection, Encoding.UTF8))
        {
        }

        private static byte[] GetCollectionBytes(IEnumerable<KeyValuePair<string, string>> c, Encoding encoding)
        {
            string str = string.Join("&", c.Select(i => string.Concat(WebUtility.UrlEncode(i.Key), '=', WebUtility.UrlEncode(i.Value))).ToArray());
            return encoding.GetBytes(str);
        }
    }
}

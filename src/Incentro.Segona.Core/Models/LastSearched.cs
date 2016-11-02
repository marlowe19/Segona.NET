using System.Collections.Generic;

namespace Incentro.Segona.Core.Models
{
    public class LastSearched
    {
        public IEnumerable<SearchItem> Items { get; set; }

        public string Kind { get; set; }

        public string Etag { get; set; }
    }
}

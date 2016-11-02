using System;

namespace Incentro.Segona.Core.Models
{
    public class Quota
    {
        public int Used { get; set; }

        public int Max { get; set; }

        public bool OverQuota { get; set; }

        public string Kind { get; set; }

        public string Etag { get; set; }
    }
}

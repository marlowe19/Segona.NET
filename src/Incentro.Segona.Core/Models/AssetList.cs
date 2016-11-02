using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Incentro.Segona.Core.Models
{
    public class AssetList
    {
        public string Cursor { get; set; }

        public IEnumerable<Asset> Items { get; set; }
    }
}

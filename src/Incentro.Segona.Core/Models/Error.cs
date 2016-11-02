using System.Collections.Generic;

namespace Incentro.Segona.Core.Models
{
    public class Error
    {
        public IEnumerable<ErrorDescription> Errors { get; set; }
    }
}

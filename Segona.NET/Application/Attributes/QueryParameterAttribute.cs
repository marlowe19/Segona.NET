using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Segona.Net.Application.Attributes
{
    public class QueryParameterAttribute: Attribute
    {
        public string Name { get; set; }
        public QueryParameterAttribute(string name)
        {
            Name = name;
        }
    }
}
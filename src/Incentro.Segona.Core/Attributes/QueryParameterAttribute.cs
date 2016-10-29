﻿using System;

namespace Incentro.Segona.Core.Attributes
{
    public class QueryParameterAttribute : Attribute
    {
        public string Name { get; set; }

        public QueryParameterAttribute(string name)
        {
            Name = name;
        }
    }
}
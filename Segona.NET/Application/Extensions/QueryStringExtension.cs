using System;
using System.Linq;
using System.Reflection;
using Segona.Net.Application.Attributes;

namespace Segona.Net.Application.Extensions
{
    public static class QueryStringExtension
    {
        public static string ToQueryString(this RequestSettings settings)
        {
            if (settings == null)
                return string.Empty;
            var output = string.Empty;
            foreach (var property in settings.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(settings)?.ToString();
                if (string.IsNullOrEmpty(propertyValue))
                    continue;
                var parameterName = property.Name;
                var attributeValue = property.GetCustomAttributes<QueryParameterAttribute>();

                if (attributeValue != null)
                {
                    parameterName = attributeValue.First().Name;
                }
                var parameterItem = $"{parameterName}={propertyValue}&";
                output = output + parameterItem;
            }
            if (string.IsNullOrEmpty(output))
            {
               throw new Exception("object does not have any properties");
              
            }
            return output.Substring(0, output.Length - 1);
        }
    }
}
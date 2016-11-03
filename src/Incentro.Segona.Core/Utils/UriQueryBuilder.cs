using System.Text;

namespace Incentro.Segona.Core.Utils
{
    public class UriQueryBuilder
    {
        private readonly StringBuilder _queryBuilder = new StringBuilder();

        public void Append(string key, object value)
        {
            if (_queryBuilder.Length > 0)
            {
                _queryBuilder.Append("&");
            }

            _queryBuilder.Append($"{key}={value}");
        }

        public string Build()
        {
            return _queryBuilder.ToString();
        }
    }
}

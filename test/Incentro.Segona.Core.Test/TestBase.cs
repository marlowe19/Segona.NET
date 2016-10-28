using System.IO;
using Incentro.Segona.Core.Configuration;
using Microsoft.Extensions.Configuration;

namespace Incentro.Segona.Core.Test
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            SegonaConfiguration = new SegonaConfiguration();
            configuration.GetSection("segona").Bind(SegonaConfiguration);
        }

        protected SegonaConfiguration SegonaConfiguration { get; set; }
    }
}

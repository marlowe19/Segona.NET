using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;

namespace Incentro.Segona.Core.Test
{
    public abstract class TestBase
    {
        public IServiceProvider Provider { get; protected set; }

        protected void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSegona(x => x.Options = Options);
            Provider = services.BuildServiceProvider();
        }

        protected TestBase()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            Options = new SegonaOptions();
            configuration.GetSection("segona").Bind(Options);

            //Configure DI
            ConfigureServices();
        }

        protected SegonaOptions Options { get; set; }
    }
}
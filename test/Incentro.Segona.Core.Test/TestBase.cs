using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Microsoft.Extensions.Logging;

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
            Options = new SegonaOptions();
            configuration.GetSection("segona").Bind(Options);
            
            ConfigureServices();

            ConfigureLogging(Provider.GetService<ILoggerFactory>());
        }

        public IServiceProvider Provider { get; protected set; }

        protected SegonaOptions Options { get; set; }

        protected void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSegona(x => x.Options = Options);
            Provider = services.BuildServiceProvider();
        }

        protected void ConfigureLogging(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();
        }
    }
}
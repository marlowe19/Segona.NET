using Incentro.Segona.Core.Abstractions;
using Incentro.Segona.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Incentro.Segona.Core.Test
{
    public abstract class TestBase
    {
        public IServiceProvider Provider { get; protected set; }

        protected void ConfigureServices()
        {
            var services = new ServiceCollection();
            ISegonaClient segonaClient = new SegonaClient(SegonaConfiguration.ApiUrl);

            services.AddSingleton<ISegonaClient>(segonaClient);

            IServiceProvider provider = services.BuildServiceProvider();

            Provider = provider;
        }

        protected TestBase()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            SegonaConfiguration = new SegonaConfiguration();
            configuration.GetSection("segona").Bind(SegonaConfiguration);

            //Configure DI
            ConfigureServices();
        }

        protected SegonaConfiguration SegonaConfiguration { get; set; }
    }
}
using System;
using Incentro.Segona.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Incentro.Segona.Core
{
    public static class ServiceCollectionExtensions
    {
        public static ISegonaBuilder AddSegona(this IServiceCollection services, Action<SegonaBuilderConfiguration> configurator = null)
        {
            services.AddSingleton<SegonaClient>();
            var configuration = new SegonaBuilderConfiguration();
            configurator?.Invoke(configuration);
            services.AddSingleton(configuration);

            services.AddLogging();

            var builder = new SegonaBuilder(services);
            builder.SetHandler<SegonaRestHandler>();
            return builder;
        }
    }
}

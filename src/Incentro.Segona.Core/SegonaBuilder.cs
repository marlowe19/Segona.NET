using Incentro.Segona.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Incentro.Segona.Core
{
    public class SegonaBuilder : ISegonaBuilder
    {
        private readonly IServiceCollection _services;

        public SegonaBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public ISegonaBuilder SetHandler<T>() where T : class, ISegonaHandler
        {
            _services.AddSingleton<ISegonaHandler, T>();
            return this;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayCore.ProductCatalog.Application.Interfaces.Log;
using PayCore.ProductCatalog.Infrastructure.LoggerManager;

namespace OnionArcExample.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ILoggerManager,LoggerManager>();
        }
    }
}

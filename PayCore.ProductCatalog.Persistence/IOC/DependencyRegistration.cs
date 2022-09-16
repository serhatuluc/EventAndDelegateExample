using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Persistence.Extension;
using PayCore.ProductCatalog.Persistence.Repositories;

namespace PayCore.ProductCatalog.Persistence.DependencyContainers
{
    public static class DependencyRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();

            // hibernate
            var connStr = configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);
        }
    }
}

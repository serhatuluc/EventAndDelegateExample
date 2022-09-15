using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayCore.ProductCatalog.Persistence.Extension;

namespace PayCore.ProductCatalog.Persistence.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            // hibernate
            var connStr = configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);
        }
    }
}

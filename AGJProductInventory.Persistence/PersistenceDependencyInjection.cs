using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGJProductInventory.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("InventoryConnectionString"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductVariationRepository, ProductVariationRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductInventoryRepository, ProductInventoryRepository>();

            return services;
        }
    }
}

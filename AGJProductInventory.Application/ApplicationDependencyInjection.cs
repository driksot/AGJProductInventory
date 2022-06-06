using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AGJProductInventory.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

using Food.Orders.Application.Domain.Persistence.EntityFramework;
using Food.Orders.Application.Domain.Persistence.Repositories;
using Food.Orders.Application.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Food.Orders.Application.Domain.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // register db context
            services.AddDbContext<EventStoreDbContext>(o =>
                o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, EventStoreDbContext>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            
            return services;
        }
    }
}
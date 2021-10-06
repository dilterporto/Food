using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders.Application.Domain.Persistence.EntityFramework
{
    public class EventStoreDbContext : DbContext
    {
        public EventStoreDbContext(DbContextOptions builderOptions)
            : base(builderOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // register all model configurations automatically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
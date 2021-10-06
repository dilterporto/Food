using Food.Orders.Application.Domain.Persistence.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Orders.Application.Domain.Persistence.EntityFramework
{
    public class OrderModelConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Merchant).HasJsonConversion().HasColumnType("jsonb");
            builder.Property(x => x.Customer).HasJsonConversion().HasColumnType("jsonb");
            builder.Property(x => x.Items).HasJsonConversion().HasColumnType("jsonb");
        }
    }
}
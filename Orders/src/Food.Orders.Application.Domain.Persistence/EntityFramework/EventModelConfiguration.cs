using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.Orders.Application.Domain.Persistence.EntityFramework
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public Guid AggregateId { get; set; }
        public string Data { get; set; }
    }
    
    public class EventModelConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Data)
                .HasColumnType("jsonb");
        }
    }
}
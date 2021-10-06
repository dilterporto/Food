using System;

namespace Food.Abstractions
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; set; }
        public Guid AggregateId { get; set; }
        public long AggregateVersion { get; set; }
        public DateTime At { get; }

        public DomainEvent(Guid aggregateId)
            : this()
        {
            AggregateId = aggregateId;
        }

        public DomainEvent(Guid aggregateId, long aggregateVersion) 
            : this(aggregateId)
        {
            AggregateVersion = aggregateVersion;
        }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            At = DateTime.UtcNow;
        }

        public abstract IDomainEvent WithAggregate(Guid aggregateId, long aggregateVersion);
    }
}
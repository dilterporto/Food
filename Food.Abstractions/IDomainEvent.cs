using System;
using MediatR;

namespace Food.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; set; }
        Guid AggregateId { get; set; }
        long AggregateVersion { get; set; }
        DateTime At { get; }
        IDomainEvent WithAggregate(Guid aggregateId, long aggregateVersion);
    }
}
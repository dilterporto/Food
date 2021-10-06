using System;
using Food.Abstractions;

namespace Food.Orders.Application.Domain.Events
{
    public class OrderConfirmedEvent : DomainEvent
    {
        internal OrderConfirmedEvent()
        {
            
        }
        
        private OrderConfirmedEvent(Guid aggregateId, long aggregateVersion) : 
            base(aggregateId, aggregateVersion)
        {
            
        }

        public override IDomainEvent WithAggregate(Guid aggregateId, long aggregateVersion)
        {
            return new OrderConfirmedEvent(aggregateId, aggregateVersion);
        }
    }
}
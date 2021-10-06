using System;
using Food.Abstractions;

namespace Food.Orders.Application.Domain.Events
{
    public class OrderPlacedEvent : DomainEvent
    {
        public Guid CustomerId { get; set; }
        public Guid MerchantId { get; set; }
        public string Notes { get; set; }

        public OrderPlacedEvent()
        {
            
        }
        internal OrderPlacedEvent(Guid customerId, Guid merchantId, string notes)
        {
            CustomerId = customerId;
            MerchantId = merchantId;
            Notes = notes;
        }
        
        private OrderPlacedEvent(Guid aggregateId, long aggregateVersion, Guid customerId, Guid merchantId, string notes) 
            : base(aggregateId, aggregateVersion)
        {
            CustomerId = customerId;
            MerchantId = merchantId;
            Notes = notes;
        }
        
        public override OrderPlacedEvent WithAggregate(Guid aggregateId, long aggregateVersion)
        {
            return new(aggregateId, aggregateVersion, CustomerId, MerchantId, Notes);
        }
    }
}
using System;
using Food.Abstractions;

namespace Food.Orders.Application.Domain.Events
{
    public class ProductAddedEvent : DomainEvent
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductAddedEvent()
        {
            
        }
        internal ProductAddedEvent(Guid productId, int quantity) 
            : base()
        {
            ProductId = productId;
            Quantity = quantity;
        }
        private ProductAddedEvent(Guid aggregateId, long aggregateVersion, Guid productId, int quantity) 
            : base(aggregateId, aggregateVersion)
        {
            ProductId = productId;
            Quantity = quantity;
        }
        public override ProductAddedEvent WithAggregate(Guid aggregateId, long aggregateVersion)
        {
            return new(aggregateId, aggregateVersion, ProductId, Quantity);
        }
    }
}
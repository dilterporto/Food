using System;
using System.Collections.Generic;
using System.Linq;
using Food.Abstractions;
using Food.Orders.Application.Domain.Entities;
using Food.Orders.Application.Domain.Events;

namespace Food.Orders.Application.Domain.Aggregates
{
    /// <summary>
    /// Order aggregate root
    /// </summary>
    public class Order : AggregateRoot
    {
        public Guid MerchantId { get; private set; }
        public string Notes { get; private set; }
        public OrderStatus Status { get; private set; }
        public Guid CustomerId { get; private set; }
        public List<OrderItem> Items { get; }
        public Order()
        {
            Items = new List<OrderItem>();
        }
        public Order(Guid id) : this()
        {
            Id = id;
        }
        public Order(Guid id, Guid customerId, Guid merchantId, string notes) : this()
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }
            if (merchantId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }
            Id = id;
            ApplyChange(new OrderPlacedEvent(customerId, merchantId, notes));
        }
        
        public void AddProduct(Guid productId, int quantity)
        {
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            if (ContainsProduct(productId))
            {
                throw new Exception($"Product {productId} already added");
            }
            ApplyChange(new ProductAddedEvent(productId, quantity));
        }

        public void Confirm()
        {
            if (Status != OrderStatus.Opened)
                throw new AggregateException($"Wrong status");
            
            ApplyChange(new OrderConfirmedEvent());
        }
        
        public void Apply(OrderPlacedEvent @event)
        {
            MerchantId = @event.MerchantId;
            Notes = @event.Notes;
            CustomerId = @event.CustomerId;
        }
        
        public void Apply(ProductAddedEvent @event)
        {
            Items.Add(new OrderItem(@event.ProductId, @event.Quantity));
        }

        public void Apply(OrderConfirmedEvent @event)
        {
            Status = OrderStatus.Confirmed;
        }
        
        private bool ContainsProduct(Guid productId)
        {
            return Items.Any(x => x.ProductId == productId);
        }
    }

    public enum OrderStatus
    {
        Opened,
        Confirmed,
        Delivered,
        Cancelled
    }
}
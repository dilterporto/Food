using System;
using System.Collections.Generic;

namespace Food.Orders.Application.Domain.Persistence.Projections
{
    public class Order
    {
        public Guid Id { get; set; }
        public Merchant Merchant { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; } = new();
    }
    
    public record Customer(Guid Id, string Name);
    public record Merchant(Guid Id, string Name);
    public record OrderItem(Guid Id, string Name, int Quantity, string Price);
    public record Product(Guid Id, string Name, double Price);
}
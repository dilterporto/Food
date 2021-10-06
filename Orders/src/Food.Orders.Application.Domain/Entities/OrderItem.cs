using System;

namespace Food.Orders.Application.Domain.Entities
{
    public record OrderItem(Guid ProductId, int Quantity);
}
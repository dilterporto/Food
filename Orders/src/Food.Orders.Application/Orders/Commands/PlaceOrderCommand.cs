using System;
using System.Collections.Generic;
using Food.Abstractions;
using Food.Orders.Application.Domain.Entities;
using MediatR;

namespace Food.Orders.Application.Orders.Commands
{
    public record PlaceOrderCommand(
        Guid CustomerId, 
        Guid MerchantId, 
        ICollection<OrderItem> Items, 
        string Notes) : ICommand<Unit>
    {
        
    }
}
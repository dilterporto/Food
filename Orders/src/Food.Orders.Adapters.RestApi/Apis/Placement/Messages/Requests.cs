using System;
using System.Collections.Generic;

namespace Food.Orders.Adapters.RestApi.Apis.Orders.Messages
{
    public record PlaceOrderRequest(
        Guid CustomerId, 
        Guid MerchantId, 
        ICollection<OrderItemRequest> Items, 
        string Notes);
    public record OrderItemRequest(Guid ProductId, int Quantity);

    public record CancelOrderRequest(Guid OrderId);
}
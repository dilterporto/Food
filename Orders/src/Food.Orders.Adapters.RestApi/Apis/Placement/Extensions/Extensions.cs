using System.Linq;
using Food.Orders.Adapters.RestApi.Apis.Orders.Messages;
using Food.Orders.Application.Domain.Entities;
using Food.Orders.Application.Orders.Commands;

namespace Food.Orders.Adapters.RestApi.Apis.Orders.Extensions
{
    public static class RequestExtensions
    {
        public static PlaceOrderCommand ToCommand(this PlaceOrderRequest request)
        {
            var items = request
                .Items
                .Select(i => new OrderItem(i.ProductId, i.Quantity))
                .ToList();

            return new PlaceOrderCommand(request.CustomerId, request.MerchantId, items, request.Notes);
        }
    }
}
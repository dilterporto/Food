using System;
using System.Threading;
using System.Threading.Tasks;
using Food.Abstractions;
using Food.Orders.Application.Domain.Aggregates;
using Food.Orders.Application.Domain.Repositories;
using MediatR;

namespace Food.Orders.Application.Orders.Commands.Handlers
{
    public class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public PlaceOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = Guid.NewGuid();
            var order = new Order(orderId, command.CustomerId, command.MerchantId, command.Notes);
            foreach (var (productId, quantity) in command.Items)
            {
                order.AddProduct(productId, quantity);
            }
            await _repository.SaveAsync(order);

            return Unit.Value;
        }
    }
}
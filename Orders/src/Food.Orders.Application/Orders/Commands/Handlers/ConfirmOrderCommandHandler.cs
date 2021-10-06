using System.Threading;
using System.Threading.Tasks;
using Food.Abstractions;
using Food.Orders.Application.Domain.Repositories;
using MediatR;

namespace Food.Orders.Application.Orders.Commands.Handlers
{
    public class ConfirmOrderCommandHandler : ICommandHandler<ConfirmOrderCommand, Unit>
    {
        private readonly IOrderRepository _repository;

        public ConfirmOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);
            order.Confirm();

            await _repository.SaveAsync(order);
            
            return Unit.Value;
        }
    }
}
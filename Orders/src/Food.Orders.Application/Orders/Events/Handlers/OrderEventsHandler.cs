using System.Threading;
using System.Threading.Tasks;
using Food.Orders.Application.Domain.Events;
using MediatR;

namespace Food.Orders.Application.Orders.Events.Handlers
{
    public class OrderEventsHandler : 
        INotificationHandler<OrderPlacedEvent>, 
        INotificationHandler<OrderConfirmedEvent>
    {
        public async Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
        {
            
        }

        public async Task Handle(OrderConfirmedEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
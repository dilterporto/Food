using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Food.Orders.Application.Domain.Events;
using Food.Orders.Application.Domain.Persistence.Projections;
using Food.Orders.Application.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders.Application.Orders.Queries.Projections.Handlers
{
    public class OrderProjectionHandlers : 
        INotificationHandler<OrderPlacedEvent>, 
        INotificationHandler<ProductAddedEvent>, 
        INotificationHandler<OrderConfirmedEvent>
    {
        private readonly DbContext _dbContext;
        private readonly IOrderRepository _repository;

        public OrderProjectionHandlers(DbContext dbContext, IOrderRepository repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }
        
        public async Task Handle(OrderPlacedEvent @event, CancellationToken cancellationToken)
        {
            var aggregate = await _repository.GetByIdAsync(@event.AggregateId);
            var orderProjection = new Order
            {
                Id = aggregate.Id,
                Status = aggregate.Status.ToString(),
                Customer = Customers.GetById(aggregate.CustomerId),
                Merchant = Merchants.GetById(aggregate.MerchantId),
                Notes = aggregate.Notes
            };

            await _dbContext.AddAsync(orderProjection, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(ProductAddedEvent @event, CancellationToken cancellationToken)
        {
            var order = _dbContext.Set<Order>().SingleOrDefault(x => x.Id == @event.AggregateId);
            var (id, name, price) = Products.GetById(@event.ProductId);
            order.Items.Add(new OrderItem(id, name, @event.Quantity, $"{price:C}"));
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(OrderConfirmedEvent @event, CancellationToken cancellationToken)
        {
            var aggregate = await _repository.GetByIdAsync(@event.AggregateId);
            var order = _dbContext.Set<Order>().SingleOrDefault(x => x.Id == @event.AggregateId);
            order.Status = aggregate.Status.ToString();
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
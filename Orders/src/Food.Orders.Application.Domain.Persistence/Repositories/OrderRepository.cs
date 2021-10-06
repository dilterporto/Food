using System;
using System.Linq;
using System.Threading.Tasks;
using Food.Orders.Application.Domain.Aggregates;
using Food.Orders.Application.Domain.Persistence.EntityFramework;
using Food.Orders.Application.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Food.Orders.Application.Domain.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _dbContext;
        private readonly IMediator _mediator;

        public OrderRepository(DbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }
        
        public async Task<Order> GetByIdAsync(Guid id)
        {
            var events = await _dbContext
                .Set<Event>()
                .Where(x => x.AggregateId == id)
                .ToListAsync();

            var order = new Order(id);
            foreach (var eventData in 
                events.Select(@event => JsonConvert.DeserializeObject(@event.Data, Type.GetType(@event.Type))))
            {
                order.ApplyChange(eventData, false);
            }
            return order;
        }

        public async Task SaveAsync(Order order)
        {
            var unCommitedChanges = order.GetUncommittedEvents();
            foreach (var unCommitedChangeEvent in unCommitedChanges)
            {
                var eventEntity = new Event
                {
                    Id = unCommitedChangeEvent.Id,
                    Data = JsonConvert.SerializeObject(unCommitedChangeEvent),
                    AggregateId = unCommitedChangeEvent.AggregateId,
                    Type = unCommitedChangeEvent.GetType().AssemblyQualifiedName,
                };
                await _dbContext.AddAsync(eventEntity);
            }
            await _dbContext.SaveChangesAsync();
            foreach (var unCommitedChangeEvent in unCommitedChanges)
            {
                await _mediator.Publish(unCommitedChangeEvent);
            }
            order.MarkChangesAsCommitted();
        }
    }
}
using Food.Abstractions;
using Food.Orders.Application.Domain.Aggregates;

namespace Food.Orders.Application.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        
    }
}
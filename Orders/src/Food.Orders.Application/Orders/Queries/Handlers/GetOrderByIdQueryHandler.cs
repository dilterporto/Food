using System.Threading;
using System.Threading.Tasks;
using Food.Orders.Application.Domain.Persistence.Projections;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders.Application.Orders.Queries.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly DbContext _dbContext;

        public GetOrderByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = _dbContext.Set<Order>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return order;
        }
    }
}
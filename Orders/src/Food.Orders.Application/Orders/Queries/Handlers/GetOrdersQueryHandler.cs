using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Food.Orders.Application.Domain.Persistence.Projections;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders.Application.Orders.Queries.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        private readonly DbContext _dbContext;

        public GetOrdersQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Order>()
                .ToListAsync(cancellationToken);
        }
    }
}
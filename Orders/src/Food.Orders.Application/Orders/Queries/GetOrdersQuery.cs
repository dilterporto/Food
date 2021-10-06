using System.Collections.Generic;
using Food.Orders.Application.Domain.Persistence.Projections;
using MediatR;

namespace Food.Orders.Application.Orders.Queries
{
    public record GetOrdersQuery : IRequest<List<Order>>;
}
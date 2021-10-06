using System;
using Food.Orders.Application.Domain.Persistence.Projections;
using MediatR;

namespace Food.Orders.Application.Orders.Queries
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<Order>;
}
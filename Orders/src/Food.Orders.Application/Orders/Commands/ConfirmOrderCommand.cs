using System;
using Food.Abstractions;

namespace Food.Orders.Application.Orders.Commands
{
    public record ConfirmOrderCommand(Guid OrderId) : ICommand;
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Food.Orders.Adapters.RestApi.Apis.Orders.Extensions;
using Food.Orders.Adapters.RestApi.Apis.Orders.Messages;
using Food.Orders.Application.Domain.Persistence.Projections;
using Food.Orders.Application.Orders.Commands;
using Food.Orders.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Food.Orders.Adapters.RestApi.Apis.Placement
{
    [ApiController]
    [Route("v1/orders")]
    [ApiExplorerSettings(GroupName = "Order Placement")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlaceOrderRequest request)
        {
            await _mediator.Send(request.ToCommand());
            return Created("", new {});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id:Guid}/confirmation")]
        public async Task<ActionResult> PostConfirmation([FromRoute] Guid id)
        {
            await _mediator.Send(new ConfirmOrderCommand(id));
            return Accepted(id);
        }
    }

    [ApiController]
    [Route("v1/orders")]
    [ApiExplorerSettings(GroupName = "Orders Query")]
    public class OrdersQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Order>> GetById([FromRoute] Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }
    }
}
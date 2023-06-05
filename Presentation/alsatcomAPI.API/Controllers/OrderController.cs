using alsatcomAPI.Application.Features.Orders.Commands;
using alsatcomAPI.Application.Features.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
            GetAllOrderQueryResponse response = await mediator.Send(getAllOrderQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdOrderQueryRequest getByIdOrderQueryRequest)
        {
            GetByIdOrderQueryResponse response = await mediator.Send(getByIdOrderQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await mediator.Send(createOrderCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest updateOrderCommandRequest)
        {
            UpdateOrderCommandResponse response = await mediator.Send(updateOrderCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderCommandRequest deleteOrderCommandRequest)
        {
            DeleteOrderCommandResponse response = await mediator.Send(deleteOrderCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}

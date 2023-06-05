using alsatcomAPI.Application.Features.Customers.Commands;
using alsatcomAPI.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            GetAllCustomerQueryResponse response = await mediator.Send(getAllCustomerQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            GetByIdCustomerQueryResponse response = await mediator.Send(getByIdCustomerQueryRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse response = await mediator.Send(createCustomerCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            UpdateCustomerCommandResponse response = await mediator.Send(updateCustomerCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            DeleteCustomerCommandResponse response = await mediator.Send(deleteCustomerCommandRequest);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}

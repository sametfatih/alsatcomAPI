using alsatcomAPI.Application.Features.Customers.Commands;
using alsatcomAPI.Application.Features.Customers.Queries;
using alsatcomAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            GetAllCustomerQueryResponse response = await mediator.Send(getAllCustomerQueryRequest);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            GetByIdCustomerQueryResponse response = await mediator.Send(getByIdCustomerQueryRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse response = await mediator.Send(createCustomerCommandRequest);
            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            UpdateCustomerCommandResponse response = await mediator.Send(updateCustomerCommandRequest);
            return Ok();
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            DeleteCustomerCommandResponse response = await mediator.Send(deleteCustomerCommandRequest);
            return Ok();
        }
    }
}

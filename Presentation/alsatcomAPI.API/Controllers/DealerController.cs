using alsatcomAPI.Application.Features.Dealers.Commands;
using alsatcomAPI.Application.Features.Dealers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        readonly IMediator mediator;

        public DealerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDealerQueryRequest getAllDealerQueryRequest)
        {
            GetAllDealerQueryResponse response = await mediator.Send(getAllDealerQueryRequest);
            if (!response.Result.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdDealerQueryRequest getByIdDealerQueryRequest)
        {
            GetByIdDealerQueryResponse response = await mediator.Send(getByIdDealerQueryRequest);
            if (!response.Result.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateDealerCommandRequest createDealerCommandRequest)
        {
            CreateDealerCommandResponse response = await mediator.Send(createDealerCommandRequest);
            if (!response.Result.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateDealerCommandRequest updateDealerCommandRequest)
        {
            UpdateDealerCommandResponse response = await mediator.Send(updateDealerCommandRequest);
            if (!response.Result.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteDealerCommandRequest deleteDealerCommandRequest)
        {
            DeleteDealerCommandResponse response = await mediator.Send(deleteDealerCommandRequest);
            if (!response.Result.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}

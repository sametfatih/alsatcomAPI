using alsatcomAPI.Application.Features.AppUsers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateAppUserCommandRequest createAppUserCommandRequest)
        {
            CreateAppUserCommandResponse response = await _mediator.Send(createAppUserCommandRequest);
            return Ok(response);
        }
    }
}

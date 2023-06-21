using alsatcomAPI.Application.Features.AppUsers.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace alsatcomAPI.API.Controllers
{
    [AllowAnonymous]
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginAppUserCommandRequest loginAppUserCommandRequest)
        {
            LoginAppUserCommandResponse response = await _mediator.Send(loginAppUserCommandRequest);
            return Ok(response);
        }
    }
}

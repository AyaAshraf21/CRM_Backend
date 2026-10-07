using crm.Application.Features.Authentication.Commands.LoginUser;
using crm.Application.Features.Authentication.Commands.RegisterAdmin;
using crm.Application.Features.Authentication.Commands.RegisterUser;
using crm.Application.Features.Authentication.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin(UserDTO userDTO)
        {
            await mediator.Send(new RegisterAdminCommand(userDTO));
            return Ok();
        }

        [HttpPost("register/employee")]
        public async Task<IActionResult> RegisterUser(UserDTO userDTO)
        {
            await mediator.Send(new RegisterUserCommand(userDTO));
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(UserDTO userDTO)
        {
            var result = await mediator.Send(new LoginUserCommand(userDTO));
            return Ok(result);
        }
    }
}

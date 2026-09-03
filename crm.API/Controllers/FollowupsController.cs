using crm.Application.Features.Followups.DTOs;
using crm.Application.Features.Followups.Queries.GetAllFollowups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowupsController : ControllerBase
    {
        private readonly IMediator mediator;
        public FollowupsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFollowups([FromQuery] FollowupQueryParameters followupQueryParameters)
        {
            var result = await mediator.Send(new GetAllFollowupsQuery(followupQueryParameters));
            return Ok(result);
        }
    }
}

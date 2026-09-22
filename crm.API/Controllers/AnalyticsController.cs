using crm.Application.Features.Analytics.Queries.GetBestPlatform;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AnalyticsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("overview/best-platform")]
        public async Task<IActionResult> GetBestPlatform()
        {
            var result = await mediator.Send(new GetBestPlatformQuery());
            return Ok(result);
        }
    }
}

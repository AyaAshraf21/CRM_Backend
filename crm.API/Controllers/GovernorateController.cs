using crm.Application.Features.Governates.Queries.GetAllGovernates;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        private readonly IMediator mediator;

        public GovernorateController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGovernorates()
        {
            var governorates =  await mediator.Send(new GetAllGovernatesQuery());
            return Ok(governorates);
        }
    }
}

using crm.Application.Features.Areas.Queries;
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

        [HttpGet("{governorateId}/areas")]
        public async Task<IActionResult> GetAllAreasByGovernorate(int governorateId)
        {
            var areas = await mediator.Send(new GetAllAreasByGovernorateQuery(governorateId));
            return Ok(new
            {
                GovernorateId = governorateId,
                Data = areas
            });
        }
    }
}

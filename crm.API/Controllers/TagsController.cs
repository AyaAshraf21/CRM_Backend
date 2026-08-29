using crm.Application.Features.Tags.Queries.GetAllTags;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public TagsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await mediator.Send(new GetAllTagsQuery());
            return Ok(tags);
        }
    }
}

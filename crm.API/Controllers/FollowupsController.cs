using crm.Application.Features.Followups.Commands.CreateFollowup;
using crm.Application.Features.Followups.Commands.DeleteFollowup;
using crm.Application.Features.Followups.Commands.UpdateFollowup;
using crm.Application.Features.Followups.Commands.UpdateFollowupStatus;
using crm.Application.Features.Followups.DTOs;
using crm.Application.Features.Followups.Queries.GetAllFollowups;
using crm.Application.Features.Followups.Queries.GetFollowupsNum;
using crm.Domain.Enums;
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

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateFollowup(int id, [FromBody] FollowupDTO followupDTO)
        {
            var result = await mediator.Send(new CreateFollowupCommand(id, followupDTO));
            return Ok(new
            {
                Message = "Followup Created Successfully",
                Data = result
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFollowup(int id, [FromBody] FollowupDTO followupDTO)
        {
            var result = await mediator.Send(new UpdateFollowupCommand(id, followupDTO));
            return Ok(new
            {
                Message = "Followup Updated Successfully",
                Data = result
            });
        }

        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> UpdateFollowupStatus(int id, Status status)
        {
            var result = await mediator.Send(new UpdateFollowupStatusCommand(id, status));
            return Ok(new
            {
                Message = "Followup Status Updated Successfully",
                Data = result
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowup(int id)
        {
            await mediator.Send(new DeleteFollowupCommand(id));
            return Ok("Followup Deleted Successfully");
        }

        [HttpGet("followups-num")]
        public async Task<IActionResult> GetFollowupsNum()
        {
            var result = await mediator.Send(new GetFollowupsNumQuery());
            return Ok(result);
        }
    }
}

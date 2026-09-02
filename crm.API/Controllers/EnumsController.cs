using crm.Application.Features.Enums.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        private readonly IMediator mediator;
        public EnumsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Status")]
        public async Task<IActionResult> GetStatus()
        {
            var result = await mediator.Send(new GetStatusQuery());
            return Ok(result);
        }

        [HttpGet("device-condition")]
        public async Task<IActionResult> GetDeviceConditions()
        {
            var result = await mediator.Send(new GetDeviceConditionQuery());
            return Ok(result);
        }

        [HttpGet("operation-type")]
        public async Task<IActionResult> GetOperationType()
        {
            var result = await mediator.Send(new GetOperationTypeQuery());
            return Ok(result);
        }

        [HttpGet("payment-type")]
        public async Task<IActionResult> GetPaymentType()
        {
            var result = await mediator.Send(new GetPaymentTypeQuery());
            return Ok(result);
        }

        [HttpGet("platform")]
        public async Task<IActionResult> GetPlatforms()
        {
            var result = await mediator.Send(new GetPlatformQuery());
            return Ok(result);
        }
    }
}

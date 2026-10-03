using crm.Application.Features.Analytics.Queries.GetBestPlatform;
using crm.Application.Features.Analytics.Queries.GetConversionRate;
using crm.Application.Features.Analytics.Queries.GetCustomerNumForThisMonth;
using crm.Application.Features.Analytics.Queries.GetSalesNum;
using crm.Application.Features.Analytics.Queries.GetSalesNumForThisMonth;
using crm.Application.Features.Analytics.Queries.GetTopDevice;
using crm.Application.Features.Analytics.Queries.GetTopGovernorate;
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

        [HttpGet("overview/top-governorate")]
        public async Task<IActionResult> GetTopGovernorate()
        {
            var result = await mediator.Send(new GetTopGovernorateQuery());
            return Ok(result);
        }

        [HttpGet("overview/top-device")]
        public async Task<IActionResult> GetTopDevice()
        {
            var result = await mediator.Send(new GetTopDeviceQuery());
            return Ok(result);
        }

        [HttpGet("main-stat/sales-count")]
        public async Task<IActionResult> GetSalesNum()
        {
            var result = await mediator.Send(new GetSalesNumQuery());
            return Ok(result);
        }

        [HttpGet("main-stat/conversion-rate")]
        public async Task<IActionResult> GetConversionRate()
        {
            var result = await mediator.Send(new GetConversionRateQuery());
            return Ok(result);
        }

        [HttpGet("main-stat/customer-count-this-month")]
        public async Task<IActionResult> GetCustomerNumForThisMonth()
        {
            var result = await mediator.Send(new GetCustomerNumForThisMonthQuery());
            return Ok(result);
        }

        [HttpGet("main-stat/sales-count-this-month")]
        public async Task<IActionResult> GetSalesNumForThisMonth()
        {
            var result = await mediator.Send(new GetSalesNumForThisMonthQuery());
            return Ok(result);
        }
    }
}

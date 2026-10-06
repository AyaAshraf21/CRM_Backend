using crm.Application.Features.Analytics.Queries.GetAverageCustomersPerMonth;
using crm.Application.Features.Analytics.Queries.GetBestMonth;
using crm.Application.Features.Analytics.Queries.GetBestPlatform;
using crm.Application.Features.Analytics.Queries.GetConversionRate;
using crm.Application.Features.Analytics.Queries.GetCustomerNumForThisMonth;
using crm.Application.Features.Analytics.Queries.GetCustomersPerMonth;
using crm.Application.Features.Analytics.Queries.GetCustomerTagAnalytics;
using crm.Application.Features.Analytics.Queries.GetDeviceConditionAnalytics;
using crm.Application.Features.Analytics.Queries.GetFollowupStatusAnalytics;
using crm.Application.Features.Analytics.Queries.GetMonthlyGrowth;
using crm.Application.Features.Analytics.Queries.GetOperationTypeAnalytics;
using crm.Application.Features.Analytics.Queries.GetPaymentTypeAnalytics;
using crm.Application.Features.Analytics.Queries.GetPlatformAnalytics;
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

        [HttpGet("main-stat/monthly-growth")]
        public async Task<IActionResult> GetMonthlyGrowth()
        {
            var result = await mediator.Send(new GetMonthlyGrowthQuery());
            return Ok(result);
        }

        [HttpGet("sales-analytics/customers-per-month")]
        public async Task<IActionResult> GetCustomersPerMonth()
        {
            var result = await mediator.Send(new GetCustomersPerMonthQuery());
            return Ok(result);
        }

        [HttpGet("sales-analytics/best-month")]
        public async Task<IActionResult> GetBestMonth()
        {
            var result = await mediator.Send(new GetBestMonthQuery());
            return Ok(result);
        }

        [HttpGet("sales-analytics/average-customers-per-month")]
        public async Task<IActionResult> GetAverageCustomersPerMonth()
        {
            var result = await mediator.Send(new GetAverageCustoemrsPerMonthQuery());
            return Ok(result);
        }

        [HttpGet("sales-analytics/platform-analytics")]
        public async Task<IActionResult> GetPlatformAnalytics()
        {
            var result = await mediator.Send(new GetPlatformAnalyticsQuery());
            return Ok(result);
        }

        [HttpGet("data-distribution/followup-status")]
        public async Task<IActionResult> GetFollowupStatusAnalytics()
        {
            var result = await mediator.Send(new GetFollowupStatusAnalyticsQuery());
            return Ok(result);
        }

        [HttpGet("data-distribution/customer-tag")]
        public async Task<IActionResult> GetCustomerTagAnalytics()
        {
            var result = await mediator.Send(new GetCustomerTagAnalyticsQuery());
            return Ok(result);
        }

        [HttpGet("data-distribution/payment-type")]
        public async Task<IActionResult> GetPaymentTypeAnalytics()
        {
            var result = await mediator.Send(new GetPaymentTypeAnalyticsQuery());
            return Ok(result);
        }

        [HttpGet("data-distribution/device-condition")]
        public async Task<IActionResult> GetDeviceConditionAnalytics()
        {
            var result = await mediator.Send(new GetDeviceConditionAnalyticsQuery());
            return Ok(result);
        }

        [HttpGet("data-distribution/operation-type")]
        public async Task<IActionResult> GetOperationTypeAnalytics()
        {
            var result = await mediator.Send(new GetOperationTypeAnalyticsQuery());
            return Ok(result);
        }
    }
}

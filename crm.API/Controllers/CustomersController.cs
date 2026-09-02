using crm.Application.Features.Customers.Commands.CreateCustomer;
using crm.Application.Features.Customers.Commands.UpdateCustomer;
using crm.Application.Features.Customers.DTOs;
using crm.Application.Features.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;
        public CustomersController (IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] CustomerQueryParameters customerQueryParameters)
        {
            var result = await mediator.Send(new GetAllCustomersQuery(customerQueryParameters));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            var result = await mediator.Send(new CreateCustomerCommand(customerDTO));
            return Ok(new
            {
                Message = "Customer Created Successfully",
                Data = result
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id,[FromBody] CustomerDTO customerDTO)
        {
            var result = await mediator.Send(new UpdateCustomerCommand(id ,customerDTO));
            return Ok(new
            {
                Message = "Customer Updated Successfully",
                Data = result
            });
        }
    }
}

using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Application.Features.Customer.Commands.CreateCustomerCommand;
using AGJProductInventory.Application.Features.Customer.Commands.DeleteCustomerCommand;
using AGJProductInventory.Application.Features.Customer.Commands.UpdateCustomerCommand;
using AGJProductInventory.Application.Features.Customer.Queries.GetCustomerDetailQuery;
using AGJProductInventory.Application.Features.Customer.Queries.GetCustomerListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> Get()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            return Ok(customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var customer = await _mediator.Send(new GetCustomerDetailQuery { Id = id });
            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<CustomerDTO>>> Post([FromBody] CustomerDTO customerDTO)
        {
            var command = new CreateCustomerCommand { CustomerDTO = customerDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse<CustomerDTO>>> Put(int id, [FromBody] CustomerDTO customerDTO)
        {
            var command = new UpdateCustomerCommand { Id = id, CustomerDTO = customerDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Delete(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

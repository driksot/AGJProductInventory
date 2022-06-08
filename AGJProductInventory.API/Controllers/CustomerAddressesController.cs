using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.CustomerAddress.Commands.CreateCustomerAddressCommand;
using AGJProductInventory.Application.Features.CustomerAddress.Commands.DeleteCustomerAddressCommand;
using AGJProductInventory.Application.Features.CustomerAddress.Commands.UpdateCustomerAddressCommand;
using AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressDetailQuery;
using AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomerAddressesController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerAddressListDTO>>> Get()
        {
            var customerAddresses = await _mediator.Send(new GetCustomerAddressListQuery());
            return Ok(customerAddresses);
        }

        // GET api/<CustomerAddressesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAddressDetailDTO>> Get(int id)
        {
            var customerAddress = await _mediator.Send(new GetCustomerAddressDetailQuery { Id = id });
            return Ok(customerAddress);
        }

        // POST api/<CustomerAddressesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<CreateCustomerAddressDTO>>> Post([FromBody] CreateCustomerAddressDTO customerAddressDTO)
        {
            var command = new CreateCustomerAddressCommand { CustomerAddressDTO = customerAddressDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CustomerAddressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse<UpdateCustomerAddressDTO>>> Put(int id, [FromBody] UpdateCustomerAddressDTO customerAddressDTO)
        {
            var command = new UpdateCustomerAddressCommand { Id = id, CustomerAddressDTO = customerAddressDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<CustomerAddressesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Delete(int id)
        {
            var command = new DeleteCustomerAddressCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

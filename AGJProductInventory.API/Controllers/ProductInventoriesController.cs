using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Application.DTOs.ProductInventory;
using AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand;
using AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryDetailQuery;
using AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryListQuery;
using AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventorySnapshotQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInventoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductInventoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductInventoriesController>
        [HttpGet]
        public async Task<ActionResult<List<ProductInventoryDTO>>> Get()
        {
            var inventoryList = await _mediator.Send(new GetProductInventoryListQuery());
            return Ok(inventoryList);
        }

        // GET api/<ProductInventoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInventoryDTO>> Get(int id)
        {
            var inventory = await _mediator.Send(new GetProductInventoryDetailQuery { Id = id });
            return Ok(inventory);
        }

        // GET api/<ProductInventoriesController>/snapshot
        [HttpGet("snapshot")]
        public async Task<ActionResult<List<ProductInventorySnapshotDTO>>> GetSnapshot()
        {
            var snapshots = await _mediator.Send(new GetProductInventorySnapshotQuery());
            return Ok(snapshots);
        }

        // PUT api/<ProductInventoriesController>/inventory/5
        [HttpPut("inventory/{id}")]
        public async Task<ActionResult<BaseCommandResponse<UpdateProductInventoryDTO>>> PutInventory(int id, [FromBody] UpdateProductInventoryDTO productInventoryDTO)
        {
            var command = new UpdateProductInventoryUnitsCommand { Id = id, ProductInventoryDTO = productInventoryDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

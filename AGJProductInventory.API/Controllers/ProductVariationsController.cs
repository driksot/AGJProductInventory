using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.DTOs.ProductVariation;
using AGJProductInventory.Application.Features.ProductVariation.Commands.CreateProductVariationCommand;
using AGJProductInventory.Application.Features.ProductVariation.Commands.DeleteProductVariationCommand;
using AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand;
using AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationDetailQuery;
using AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductVariationsController>
        [HttpGet("product/{id}")]
        public async Task<ActionResult<List<ProductVariationDTO>>> GetAllByProduct(int id)
        {
            var productVariations = await _mediator.Send(new GetProductVariationListQuery { ProductId = id });
            return Ok(productVariations);
        }

        // GET api/<ProductVariationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVariationDTO>> Get(int id)
        {
            var productVariation = await _mediator.Send(new GetProductVariationDetailQuery { Id = id });
            return Ok(productVariation);
        }

        // POST api/<ProductVariationsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<CreateProductVariationDTO>>> Post([FromBody] CreateProductVariationDTO productVariationDTO)
        {
            var command = new CreateProductVariationCommand { ProductVariationDTO = productVariationDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProductVariationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse<ProductVariationDTO>>> Put(int id, [FromBody] ProductVariationDTO productVariationDTO)
        {
            var command = new UpdateProductVariationCommand { Id = id, ProductVariationDTO = productVariationDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<ProductVariationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Delete(int id)
        {
            var command = new DeleteProductVariationCommand { Id = id };
            var response = await _mediator.Send(command);
            return response;
        }
    }
}

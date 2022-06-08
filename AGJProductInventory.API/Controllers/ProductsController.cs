using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand;
using AGJProductInventory.Application.Features.Product.Commands.DeleteProductCommand;
using AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand;
using AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery;
using AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery;
using AGJProductInventory.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductListDTO>>> Get()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDTO>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductDetailQuery { Id = id });
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<Product>>> Post([FromBody] CreateProductDTO productDTO)
        {
            var command = new CreateProductCommand { ProductDTO = productDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse<UpdateProductDTO>>> Put(int id, [FromBody] UpdateProductDTO productDTO)
        {
            var command = new UpdateProductCommand { Id = id, ProductDTO = productDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

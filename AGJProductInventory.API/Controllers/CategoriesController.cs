using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Commands.DeleteCategoryCommand;
using AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery;
using AGJProductInventory.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryListDTO>>> Get()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailDTO>> Get(int id)
        {
            var category = await _mediator.Send(new GetCategoryDetailQuery { Id = id });
            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<Category>>> Post([FromBody] CreateCategoryDTO categoryDTO)
        {
            var command = new CreateCategoryCommand { CategoryDTO = categoryDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCategoryDTO categoryDTO)
        {
            var command = new UpdateCategoryCommand { CategoryDTO = categoryDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

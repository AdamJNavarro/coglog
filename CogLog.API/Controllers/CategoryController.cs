using CogLog.App.Contracts.Data.Category;
using CogLog.App.Features.Category.Commands;
using CogLog.App.Features.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = "CategoriesGet")]
    public async Task<List<CategoryMinimalDto>> Get()
    {
        return await mediator.Send(new GetCategoriesQuery());
    }

    [HttpGet("{id:int}/details", Name = "CategoryGetDetails")]
    public async Task<ActionResult<CategoryDetailsDto>> CategoryGetDetails(int id)
    {
        var data = await mediator.Send(new GetCategoryDetailsQuery(id));
        return Ok(data);
    }

    // POST
    [HttpPost(Name = "CategoryCreate")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateCategoryCommand category)
    {
        var resp = await mediator.Send(category);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [HttpPut("{id:int}", Name = "CategoryUpdate")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateCategoryCommand category)
    {
        await mediator.Send(category);
        return NoContent();
    }

    // DELETE
    [HttpDelete(Name = "CategoryDelete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}

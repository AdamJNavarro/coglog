using CogLog.App.Contracts.Data;
using CogLog.App.Features.Category.Commands;
using CogLog.App.Features.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController(IMediator mediator) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<List<CategoryDto>> Get()
    {
        return await mediator.Send(new GetCategoriesQuery());
    }

    [HttpGet("{id:int}/subjects")]
    public async Task<ActionResult<CategoryWithSubjectsDto>> GetWithSubjects(int id)
    {
        var data = await mediator.Send(new GetCategoryWithSubjectsQuery(id));
        return Ok(data);
    }

    [HttpGet("{id:int}/brainblocks")]
    public async Task<ActionResult<CategoryWithSubjectsDto>> GetWithCategories(int id)
    {
        var data = await mediator.Send(new GetCategoryWithBrainBlocksQuery(id));
        return Ok(data);
    }

    // POST
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateCategoryCommand category)
    {
        var resp = await mediator.Send(category);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [HttpPut("{id:int}")]
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
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}

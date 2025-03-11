using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Features.Subject.Commands;
using CogLog.App.Features.Subject.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/subjects")]
[ApiController]
public class SubjectController(IMediator mediator) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok();
    }

    [HttpGet("{id:int}", Name = "SubjectsGetOne")]
    public async Task<ActionResult<SubjectDto>> GetOne(int id)
    {
        var topic = await mediator.Send(new GetSubjectQuery(id));
        return Ok(topic);
    }

    [HttpGet("{categoryId:int}", Name = "SubjectsByCategoryGET")]
    public async Task<List<SubjectDto>> GetByCategory(int categoryId)
    {
        return await mediator.Send(new GetSubjectsByCategoryQuery(categoryId));
    }

    [HttpGet]
    [Route("{id:int}/topics", Name = "SubjectWithCategoryTopicsGET")]
    public async Task<ActionResult<SubjectWithCategoryTopicsDto>> Get(int id)
    {
        var data = await mediator.Send(new GetSubjectWithCategoryTopicsQuery(id));
        return Ok(data);
    }

    [HttpGet]
    [Route("{id:int}/blocks", Name = "SubjectWithBlocksGET")]
    public async Task<ActionResult<SubjectWithBlocksDto>> GetWithBlocks(int id)
    {
        var data = await mediator.Send(new GetSubjectWithBlocksQuery(id));
        return Ok(data);
    }

    // POST
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateSubjectCommand command)
    {
        var resp = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateSubjectCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    // DELETE
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteSubjectCommand(id));
        return NoContent();
    }
}

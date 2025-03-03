using CogLog.App.Contracts.Data;
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

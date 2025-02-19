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

    [HttpGet("{id:int}/blocks")]
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
}

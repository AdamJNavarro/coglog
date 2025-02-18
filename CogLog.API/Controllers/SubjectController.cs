using CogLog.App.Features.Subject.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/subject")]
[ApiController]
public class SubjectController(IMediator mediator) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok();
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

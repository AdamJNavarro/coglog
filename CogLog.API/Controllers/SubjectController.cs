using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Features.Subject.Commands;
using CogLog.App.Features.Subject.Queries;
using CogLog.App.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/subjects")]
[ApiController]
public class SubjectController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = "SubjectsGetPaginated")]
    public async Task<ActionResult<PaginationResponse<SubjectPaginatedDto>>> Get(
        [FromQuery] SubjectQueryParameters parameters
    )
    {
        return await mediator.Send(new GetPaginatedSubjectsQuery(parameters));
    }

    [HttpGet("all", Name = "SubjectsGetAll")]
    public async Task<List<SubjectMinimalDto>> Get([FromQuery] int? categoryId)
    {
        return await mediator.Send(new GetAllSubjectsQuery(categoryId));
    }

    [HttpGet("{id:int}", Name = "SubjectGetDetails")]
    public async Task<ActionResult<SubjectDetailsDto>> GetDetails(int id)
    {
        var topic = await mediator.Send(new GetSubjectDetailsQuery(id));
        return Ok(topic);
    }

    // POST
    [Authorize]
    [HttpPost(Name = "SubjectCreate")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateSubjectCommand command)
    {
        var resp = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [Authorize]
    [HttpPut("{id:int}", Name = "SubjectUpdate")]
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
    [Authorize]
    [HttpDelete(Name = "SubjectDelete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteSubjectCommand(id));
        return NoContent();
    }
}

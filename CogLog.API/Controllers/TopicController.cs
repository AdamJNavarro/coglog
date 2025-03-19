using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Features.Topic.Commands;
using CogLog.App.Features.Topic.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/topics")]
[ApiController]
public class TopicController(IMediator mediator) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<List<TopicMinimalDto>> Get()
    {
        return await mediator.Send(new GetAllTopicsQuery(null));
    }

    [HttpGet("{id:int}", Name = "TopicGetDetails")]
    public async Task<ActionResult<TopicDetailsDto>> GetDetails(int id)
    {
        var topic = await mediator.Send(new GetTopicDetailsQuery(id));
        return Ok(topic);
    }

    [HttpGet("all", Name = "TopicsGetAll")]
    public async Task<List<TopicMinimalDto>> GetAll([FromQuery] int? subjectId)
    {
        return await mediator.Send(new GetAllTopicsQuery(subjectId));
    }

    // POST
    [Authorize]
    [HttpPost(Name = "TopicCreate")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateTopicCommand command)
    {
        var resp = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [Authorize]
    [HttpPut("{id:int}", Name = "TopicUpdate")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateTopicCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    // DELETE
    [Authorize]
    [HttpDelete(Name = "TopicDelete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteTopicCommand(id));
        return NoContent();
    }
}

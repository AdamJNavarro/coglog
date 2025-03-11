using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Features.Topic.Commands;
using CogLog.App.Features.Topic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/topics")]
[ApiController]
public class TopicController(IMediator mediator) : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok();
    }

    [HttpGet("{id:int}", Name = "TopicsGetOne")]
    public async Task<ActionResult<TopicDto>> GetOne(int id)
    {
        var topic = await mediator.Send(new GetTopicQuery(id));
        return Ok(topic);
    }

    [HttpGet("{subjectId:int}", Name = "TopicsBySubjectGET")]
    public async Task<List<TopicDto>> GetBySubject(int subjectId)
    {
        return await mediator.Send(new GetTopicsBySubjectQuery(subjectId));
    }

    // POST
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateTopicCommand command)
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
    public async Task<ActionResult> Put(UpdateTopicCommand command)
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
        await mediator.Send(new DeleteTopicCommand(id));
        return NoContent();
    }
}

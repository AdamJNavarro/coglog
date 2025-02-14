using CogLog.App.Features.Topic.Create;
using CogLog.App.Features.Topic.Delete;
using CogLog.App.Features.Topic.Get;
using CogLog.App.Features.Topic.GetById;
using CogLog.App.Features.Topic.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicController : ControllerBase
{
    private readonly IMediator _mediator;

    public TopicController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET
    [HttpGet]
    public async Task<List<TopicDto>> Get()
    {
        var topics = await _mediator.Send(new GetTopicsQuery());
        return topics;
    }

    // GET BY ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TopicDto>> Get(int id)
    {
        var topic = await _mediator.Send(new GetTopicByIdQuery(id));
        return topic;
    }

    // POST
    [Authorize]
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateTopicCommand topic)
    {
        var resp = await _mediator.Send(topic);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateTopicCommand topic)
    {
        await _mediator.Send(topic);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var cmd = new DeleteTopicCommand(id);
        await _mediator.Send(cmd);
        return NoContent();
    }
}

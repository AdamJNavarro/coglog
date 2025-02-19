using CogLog.App.Contracts.Data;
using CogLog.App.Features.BrainBlock.Commands;
using CogLog.App.Features.BrainBlock.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers
{
    [Route("api/brainblocks")]
    [ApiController]
    public class BrainBlockController(IMediator mediator) : ControllerBase
    {
        // GET: api/<BrainBlockController>
        [HttpGet]
        public async Task<List<BrainBlockDto>> Get()
        {
            return await mediator.Send(new GetBrainBlocksQuery());
        }

        // POST api/<BrainBlockController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateBrainBlockCommand brainBlock)
        {
            var resp = await mediator.Send(brainBlock);
            return CreatedAtAction(nameof(Get), new { id = resp });
        }

        // DELETE api/<BrainBlockController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteBrainBlockCommand(id));
            return NoContent();
        }
    }
}

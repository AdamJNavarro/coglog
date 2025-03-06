using CogLog.App.Contracts.Data.Block;
using CogLog.App.Features.Block.Commands;
using CogLog.App.Features.Block.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers
{
    [Route("api/blocks")]
    [ApiController]
    public class BlockController(IMediator mediator) : ControllerBase
    {
        // GET: api/<BlockController>
        [HttpGet]
        public async Task<List<BlockDto>> Get()
        {
            return await mediator.Send(new GetBlocksQuery());
        }

        [HttpGet]
        [Route("by-day", Name = "BlocksByDayGET")]
        public async Task<List<BlocksByDayDto>> GetBlocksByDay()
        {
            return await mediator.Send(new GetBlocksByDayQuery());
        }

        // POST api/<BlockController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateBlockCommand block)
        {
            var resp = await mediator.Send(block);
            return CreatedAtAction(nameof(Get), new { id = resp });
        }

        // DELETE api/<BlockController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteBlockCommand(id));
            return NoContent();
        }
    }
}

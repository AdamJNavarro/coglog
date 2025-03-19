using CogLog.App.Contracts.Data.Block;
using CogLog.App.Features.Block.Commands;
using CogLog.App.Features.Block.Queries;
using CogLog.App.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers
{
    [Route("api/blocks")]
    [ApiController]
    public class BlockController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginationResponse<BlockDto>>> Get(
            [FromQuery] BlocksQueryParameters parameters
        )
        {
            return await mediator.Send(new GetBlocksQuery(parameters));
        }

        [HttpGet]
        [Route("by-day", Name = "BlocksByDayGET")]
        public async Task<List<BlocksByDayDto>> GetBlocksByDay()
        {
            return await mediator.Send(new GetBlocksByDayQuery());
        }

        [HttpGet("{id:int}/details", Name = "BlockGetDetails")]
        public async Task<ActionResult<BlockDetailsDto>> BlockGetDetails(int id)
        {
            var data = await mediator.Send(new GetBlockDetailsQuery(id));
            return Ok(data);
        }

        // POST api/<BlockController>
        [Authorize]
        [HttpPost(Name = "BlockCreate")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateBlockCommand block)
        {
            var resp = await mediator.Send(block);
            return CreatedAtAction(nameof(Get), new { id = resp });
        }

        [Authorize]
        [HttpPut("{id:int}", Name = "BlockUpdate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBlockCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<BlockController>/5
        [Authorize]
        [HttpDelete("{id:int}", Name = "BlockDelete")]
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

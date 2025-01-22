using CogLog.App.Features.BrainBlock.Create;
using CogLog.App.Features.BrainBlock.Delete;
using CogLog.App.Features.BrainBlock.Get;
using CogLog.App.Features.BrainBlock.GetById;
using CogLog.App.Features.BrainBlock.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrainBlockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrainBlockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BrainBlockController>
        [HttpGet]
        public async Task<List<BrainBlockDto>> Get()
        {
            var brainBlocks = await _mediator.Send(new GetBrainBlocksQuery());
            return brainBlocks;
        }

        // GET api/<BrainBlockController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BrainBlockDetailsDto>> Get(int id)
        {
            var brainBlock = await _mediator.Send(new GetBrainBlockByIdQuery(id));
            return Ok(brainBlock);
        }

        // POST api/<BrainBlockController>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateBrainBlockCommand brainBlock)
        {
            var resp = await _mediator.Send(brainBlock);
            return CreatedAtAction(nameof(Get), new { id = resp });
        }

        // PUT api/<BrainBlockController>/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBrainBlockCommand brainBlock)
        {
            await _mediator.Send(brainBlock);
            return NoContent();
        }

        // DELETE api/<BrainBlockController>/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var cmd = new DeleteBrainBlockCommand(id);
            await _mediator.Send(cmd);
            return NoContent();
        }
    }
}

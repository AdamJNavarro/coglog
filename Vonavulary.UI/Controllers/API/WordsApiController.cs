using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.App.Features.Word.Commands;
using Vonavulary.App.Features.Word.Queries;
using Vonavulary.App.Models.Pagination;

namespace Vonavulary.UI.Controllers.API;

[ApiController]
[Route("api/words")]
public class WordsApiController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = "WordsGet")]
    public async Task<ActionResult<PaginationResponse<WordDto>>> Get(
        [FromQuery] WordsQueryParameters parameters
    )
    {
        return await mediator.Send(new GetWordsQuery(parameters));
    }

    [HttpGet("{id:int}/details", Name = "WordGetDetails")]
    public async Task<ActionResult<WordDto>> WordGetDetails(int id)
    {
        var data = await mediator.Send(new GetWordDetailsQuery(id));
        return Ok(data);
    }

    [Authorize(Policy = "ApiPolicy")]
    [HttpPost(Name = "WordCreate")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateWordCommand word)
    {
        var resp = await mediator.Send(word);
        return CreatedAtAction(nameof(Get), new { id = resp });
    }

    // PUT
    [Authorize(Policy = "ApiPolicy")]
    [HttpPut("{id:int}", Name = "WordUpdate")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateWordCommand word)
    {
        await mediator.Send(word);
        return NoContent();
    }

    // DELETE
    [Authorize(Policy = "ApiPolicy")]
    [HttpDelete(Name = "WordDelete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteWordCommand(id));
        return NoContent();
    }
}

using MediatR;
using POS.Application.Items.Queries;
using POS.Application.Items.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Policy = "is-admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateItem request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet("itemId")]
    public async Task<ActionResult> Get([FromQuery] int itemId)
    {
        var response = await _mediator.Send(new GetItem(itemId));

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var response = await _mediator.Send(new BrowseItems());

        return Ok(response);
    }

    [HttpGet("categoryId")]
    public async Task<ActionResult> GetProductsByCateogryId([FromQuery] int categoryId)
    {
        var response = await _mediator.Send(new GetItemsByCategoryId(categoryId));

        return Ok(response);
    }
}


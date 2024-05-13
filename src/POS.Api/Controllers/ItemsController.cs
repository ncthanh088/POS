using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.Application.Items.Queries;
using POS.Application.Items.Commands;

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

    [HttpGet("{itemID}")]
    public async Task<ActionResult> Get(int itemID)
    {
        var response = await _mediator.Send(new GetItem(itemID));

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var response = await _mediator.Send(new BrowseItems());

        return Ok(response);
    }

    [HttpGet("categoryID")]
    public async Task<ActionResult> GetProductsByCateogryId([FromQuery] int categoryID)
    {
        var response = await _mediator.Send(new GetItemsByCategoryID(categoryID));

        return Ok(response);
    }
}


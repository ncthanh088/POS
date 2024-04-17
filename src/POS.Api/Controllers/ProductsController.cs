using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.Application.Products.Commands;
using POS.Application.Products.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Policy = "is-admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateProduct request)
    {
        await _mediator.Send(request);

        return NoContent();
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult> Get(Guid productId)
    {
        var response = await _mediator.Send(new GetProduct(productId));

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var response = await _mediator.Send(new BrowseProducts());

        return Ok(response);
    }
}


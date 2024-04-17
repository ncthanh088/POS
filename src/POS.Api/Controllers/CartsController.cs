using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTO;
using POS.Application.Carts.Commands;
using POS.Application.Carts.Queries;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<CartDto>> GetAsync([FromRoute] Guid userId)
    {
        var response = await _mediator.Send(new GetCart(UserId: userId));

        return Ok(response);
    }

    [HttpPost("items")]
    public async Task<IActionResult> PostAsync(AddItemToCart request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete("{userId}/items/{productId}")]
    public async Task<IActionResult> RemoveAsync(Guid userId, Guid productId)
    {
        var response = await _mediator
            .Send(new RemoveItemFromCart(UserId: userId, productId));

        return Ok(response);
    }

    [HttpDelete("userId")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid userId)
    {
        return Ok(await _mediator.Send(new ClearCart(userId)));
    }
}


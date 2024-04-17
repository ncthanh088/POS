using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Orders.Commands;
using POS.Application.Orders.Queries;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetAllAsync([FromQuery] BrowseOrders request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var response = await _mediator.Send(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateOrder request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("{id}/complete")]
    public async Task<IActionResult> CompleteAsync(Guid id, CompleteOrder request)
    {
        var response = await _mediator.Send(request with { OrderId = id });
        return Ok(response);
    }

    //[AdminAuth]
    [HttpPost("{id}/approve")]
    public async Task<IActionResult> ApproveAsync(Guid id, ApproveOrder request)
    {
        var response = await _mediator.Send(request with { OrderId = id });
        return Ok(response);
    }

    [HttpDelete("{userId}/items/{orderId}")]
    public async Task<IActionResult> Delete(Guid userId, Guid orderId)
    {
        var request = new CancelOrder(userId, orderId);
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}

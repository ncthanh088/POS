using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTO;
using POS.Application.Payments.Commands;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("process-payment")]
    public async Task<ActionResult<ProcessSaleTransactionDto>> ProcessPaymentAsync(ProcessSaleTransaction request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("calculate-sale-transaction")]
    public async Task<IActionResult> CalculateSaleTransactionAsync([FromBody] CalculateSaleTransaction request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("sale-transaction")]
    public async Task<IActionResult> CreateSaleTransactionAsync([FromBody] CreateSaleTransaction request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}

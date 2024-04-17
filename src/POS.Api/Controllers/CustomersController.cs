using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Customers;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateCustomer request)
    {
        return Ok(await _mediator.Send(request));
    }
}


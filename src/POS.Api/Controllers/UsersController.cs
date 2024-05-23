using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.Application.DTO;
using POS.Application.Security;
using POS.Application.Users.Commands;
using POS.Application.Users.Queries;

namespace POS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenStorage _tokenStorage;

    public UsersController(IMediator mediator, ITokenStorage tokenStorage)
    {
        _mediator = mediator;
        _tokenStorage = tokenStorage;
    }

    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> Get()
    {
        if (string.IsNullOrWhiteSpace(User.Identity?.Name))
            return NotFound();

        var userId = int.Parse(User.Identity?.Name);
        var user = await _mediator.Send(new GetUser { UserId = userId });

        return user;
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult<JwtDto>> Post(SignIn request)
    {
        await _mediator.Send(request);
        var jwt = _tokenStorage.Get();

        return jwt;
    }

    [HttpPost("sign-up")]
    public async Task<ActionResult> Post(SignUp request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}

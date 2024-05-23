using MediatR;
using POS.Domain.Entities;
using POS.Application.DTO;
using POS.Application.Repositories;
using POS.Application.Exceptions;

namespace POS.Application.Users.Queries.Handlers;

internal sealed class GetUserHandler : IRequestHandler<GetUser, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUser request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(request.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        return user;
    }
}

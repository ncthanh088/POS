using MediatR;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;
using POS.Application.DTO;
using POS.Application.Repositories;
using POS.Application.Exceptions;

namespace POS.Application.Users.Queries.Handlers;

internal sealed class GetUserHandler : IRequestHandler<GetUser, UserDto>
{
    private readonly IRepository<User> _userRepository;

    public GetUserHandler(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUser request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(x => x.Id == new UserId(request.UserId));

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        return user.AsDto();

    }
}

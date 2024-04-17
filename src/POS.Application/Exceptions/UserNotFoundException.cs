using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions;

public class UserNotFoundException : GlobalException
{
    public Guid UserId { get; }
    public UserNotFoundException(Guid userId) : base($"User: '{userId}' not found.")
    {
        UserId = userId;
    }

}

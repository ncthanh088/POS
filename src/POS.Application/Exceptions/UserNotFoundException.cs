using POS.Domain.Exceptions.Abstractions;

namespace POS.Application.Exceptions;

public class UserNotFoundException : GlobalException
{
    public int UserId { get; }
    public UserNotFoundException(int userId) : base($"User: '{userId}' not found.")
    {
        UserId = userId;
    }

}

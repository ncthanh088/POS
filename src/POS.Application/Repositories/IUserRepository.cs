using POS.Application.DTO;

namespace POS.Application.Repositories;

public interface IUserRepository
{
    Task<UserDto> GetUserAsync(int userId);
}

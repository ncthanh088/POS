using POS.Application.DTO;
using POS.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace POS.Infrastructure.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly POSDbContext _dbContext;

    public UserRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<UserDto> GetUserAsync(int userId)
    {
        return _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == userId)
            .ContinueWith(x => UserDto.Parse(x.Result));
    }
}

using POS.WebApp.Models;

namespace POS.WebApp.Services
{
    public interface IAuthService
    {
        Task<JwtDto> SignIn(string username, string password);
        Task<User> GetUserInfoAsync();
    }
}

using POS.WebApp.Models;
using POS.WebApp.Models.Auth;

namespace POS.WebApp.Services
{
    public interface IAuthService
    {
        Task<Jwt> SignIn(string username, string password);
        Task<UserInfo> GetUserInfoAsync();
    }
}

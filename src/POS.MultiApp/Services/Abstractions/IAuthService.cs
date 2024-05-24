using POS.MultiApp.Models;
using POS.MultiApp.Models.Auth;

namespace POS.MultiApp.Services
{
    public interface IAuthService
    {
        Task<Jwt> SignIn(string username, string password);
        Task LogoutAsync();
        Task<UserInfo> GetOrCreateUserInfoAsync();
    }
}

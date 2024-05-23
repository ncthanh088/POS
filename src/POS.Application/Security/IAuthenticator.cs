using POS.Application.DTO;

namespace POS.Application.Security
{
    public interface IAuthenticator
    {
        JwtDto CreateToken(int userId, string role);
    }
}

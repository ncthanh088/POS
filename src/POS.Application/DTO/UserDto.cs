using System.Linq.Expressions;
using POS.Domain.Entities;

namespace POS.Application.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Status { get; set; }
    public string Role { get; set; }

    public static Expression<Func<User, UserDto>> Expression
    {
        get
        {
            return user => new UserDto
            {
                Id = user.Id,
                UserName = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Role = user.Role,
            };
        }
    }

    public static UserDto Parse(User user)
    {
        if (user == null)
            return null;
        
        return Expression.Compile().Invoke(user);
    }
}

using MediatR;
using POS.Application.DTO;

namespace POS.Application.Users.Queries
{
    public class GetUser : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}

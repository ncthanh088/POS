using MediatR;
using POS.Application.DTO;
using POS.Domain.ValueObjects;

namespace POS.Application.Users.Queries
{
    public class GetUser : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}

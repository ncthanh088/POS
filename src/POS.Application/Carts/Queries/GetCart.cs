using MediatR;
using POS.Application.DTO;

namespace POS.Application.Carts.Queries;

public record GetCart(Guid UserId) : IRequest<CartDto>;

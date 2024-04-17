using MediatR;
using POS.Application.DTO;

namespace POS.Application.Carts.Commands;

public record AddItemToCart(Guid UserId, Guid ItemId, int Quantity) : IRequest<CartDto>;

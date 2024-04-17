using MediatR;

namespace POS.Application.Carts.Commands;

public record RemoveItemFromCart(Guid UserId, Guid ProductId) : IRequest;

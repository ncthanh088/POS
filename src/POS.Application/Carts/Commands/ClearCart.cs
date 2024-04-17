using MediatR;

namespace POS.Application.Carts.Commands;

public record ClearCart(Guid UserId) : IRequest;
